using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HslCommunication.LogNet;
using SharpConfig;

namespace DG_Measure
{
    public partial class MainView : DevExpress.XtraBars.TabForm
    {
        DB_Operate DB_Work;//工作数据
        DB_Operate DB_Operate;//用户数据库操作
        ReadValue ReadPLCValue = new ReadValue();//数值操作        
        ValueChange WorkProcess = new ValueChange();//工作流程
        UInt16 WorkMode = 0;//等于0时为测7点模式，等1时为测13点，2平面比较模式,等于2时为测9点模式
        bool Workstatus = false;//刷新工作状态
        bool FirstSign = false;
        string[] UserList = null;
        static public string usmen;//用户名，用于保存
        static public string uspass;//密码，用于保存
        public static ILogNet Log;//日志记录
        public static RS232 CodeDevice; //扫码枪
        Parameter SysPara;//系统参数
        static int OpenFormCount = 1;
        //申明分页变量
        int cRows = 0;//总行数
        int RowCurrent = 0;//当前显示行数
        int cPages = 0;//总页数
        int PageCurrent = 0;//当前页数
        DataTable dtTemp;
        public MainView()
        {            
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
            //读取系统参数
            SysPara = OperatePara.LoadPara("Para.cfg");
            DB_Operate = new DB_Operate(SysPara.UserDB, SysPara.UserTB,SysPara.UserPath);//指定用户数据库和表
            DB_Work = new DB_Operate(SysPara.WorkDB, SysPara.WorkTB, SysPara.WorkPath);//指定工作数据库和表
            //页面跳转
            getUserList();
            if (!getAuthority())
            {                
                this.TabControl.SelectedPage = this.TabControl.Pages[0];//跳转到登录页面
            }
            FirstSign = true;
            //创建页面
            if (TabControl.SelectedPage.Text == "用户")
            {
                //刷新列表
                getUserList();
                User_List.SelectedIndex = 0;
            }
            //DB_Work.DB_Table.RowChanged += new DataRowChangeEventHandler(refreshDB);
            //配置连接参数
            ReadPLCValue = new ReadValue(SysPara.PlcIp, SysPara.PlcPort, SysPara.PlcSA1, SysPara.PlcDA1, SysPara.PlcDA2);
            plcStatus();
            //配置流程参数
            WorkProcess.equal1ClearEvent += new ValueChange.Change_Event(workProcessClear);//清空参数
            WorkProcess.equal1Event += new ValueChange.Change_Event(workProcessGoing);//==1触发读取流程参数
            //配置Log参数
            Log = new LogNetDateTime("./Log",GenerateMode.ByEveryHour);
            //配置扫码枪参数
            CodeDevice = new RS232();
            CodeDevice.Receive_Event += new Receive_Delegate(CodeResolve);
            //刷新串口列表
            Com_List.Items.AddRange(CodeDevice.PortName.ToArray());
            Com_List.SelectedIndex = SysPara.PortNo;
            //连接扫码枪
            OpenCodeDevice();
            //判断OK/NG
            judgeEnable.Checked = SysPara.Judge;
            JudgeDisable.Checked = !SysPara.Judge;
            //User管理
            userListEdit.DataSource = DB_Operate.DB_Table;
            //主页的信息显示
            InitialData();
        }
        void OnOuterFormCreating(object sender, OuterFormCreatingEventArgs e)
        {
            MainView form = new MainView();
            form.TabFormControl.Pages.Clear();
            e.Form = form;
            OpenFormCount++;
        }    
        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
            fluent.BindCommand(TabControl.AddPageButton, x => x.Show());
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void getUserList()
        {
            UserList = null;
            UserList = DB_Operate.getUserList("User_Name").ToArray();
            //刷新列表
            User_List.Properties.Items.Clear();
            User_List.Properties.Items.AddRange(UserList.OrderBy(x => x).ToArray());
        }
        /// <summary>
        /// 连接PLC并刷新状态
        /// </summary>
        private void plcStatus()
        {
            if (ReadPLCValue.openConnectPLC())
            {
                plcStatusButton.Caption = "PLC在线";
            }
            else
            {
                plcStatusButton.Caption = "PLC离线";
            }
        }
        /// <summary>
        /// 更新工作状态
        /// </summary>
        private void workProcessRefresh()
        {
            if (!Workstatus)
            {
                WorkProcess.Variable = ReadPLCValue.Process;//更新工作状态
                WorkMode = ReadPLCValue.Mode;//更新当前模式
            }            
        }
        /// <summary>
        /// 清空工作状态
        /// </summary>
        private void workProcessClear()
        {
            //ReadPLCValue.Process = 0;
            MessageBox.Show("清除OK");
        }
        /// <summary>
        /// 工作状态数据处理
        /// </summary>
        private void workProcessGoing()
        {
            //终止刷新
            Workstatus = true;
            //数据读取代码
            ReadPLCValue.readValue();
            //判断数据

            //输出判断结果

            //释放刷新
            Workstatus = false;
        }
        /// <summary>
        /// 判断是否选择正确的用户名或密码
        /// </summary>
        /// <returns></returns>
        private bool pdyj()
        {
            //用if来判断框的内容
            if (User_List.SelectedItem.ToString() == "")//用户选择
                return false;
            if (Password_Input.Text == "")//密码输入
                return false;
            return true;
        }
        /// <summary>
        /// 用户登录  确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Button_Click(object sender, EventArgs e)
        {
            login();
        }
        /// <summary>
        /// 登录
        /// </summary>
        private void login()
        {
            //判断输入信息
            if (!pdyj())
            {
                MessageBox.Show("请输入正确信息");
                return;
            }
            string Access = "select User_Name,User_Password from [User] where User_Name = '" + User_List.SelectedItem.ToString() + "' and User_Password = '" + Password_Input.Text + "'";
            if (DB_Operate.questDB(Access))
            {
                usmen = User_List.SelectedItem.ToString();
                barHeaderUser.Caption = "当前用户：" + usmen;
                Password_Input.Text = "";
                this.TabControl.SelectedPage = this.TabControl.Pages[1];//跳转到主页
                MessageBox.Show("登录成功！");
            }
            else
            {
                Password_Input.Text = "";
                MessageBox.Show("用户名或密码错误！！");
            }
        }
        /// <summary>
        /// 用户登录  取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Password_Input.Text = "";//清空密码输入框
            Dictionary<string, object> keys = new Dictionary<string, object>
            {
                {"序号", "02"},
                {"测量模式", "02"},
                {"条码", "02"},
                {"生产时间", "02"},
                {"操作员ID", "02"},
                {"班次", "02"},
                {"设备ID", "02"},
                {"工序名", "02"},
                {"判定结果", "02"},
                {"电池厚度", "02"},
                {"电池宽度", "02"},
                {"电池壳体高度", "02"},
                {"电池A面多点凸度", "02"},
                {"电池B面多点凸度", "02"},
                {"电池正极极柱高", "02"},
                {"电池负极极柱高", "02"},
                {"电池正极极柱平面度", "02"},
                {"电池负极极柱平面度", "02"},
                {"电池正负极柱平行度", "02"},
                {"电池负正极柱平行度", "02"},
                {"电池正极柱与底部平行度", "02"},
                {"电池负极柱与底部平行度", "02"},
                {"MP1aToMP1b厚度", "02"},
                {"MP2aToMP2b厚度", "02"},
                {"MP3aToMP3b厚度", "02"},
                {"MP4aToMP4b厚度", "02"},
                {"MP5aToMP5b厚度", "02"},
                {"MP6aToMP6b厚度", "02"},
                {"MP7aToMP7b厚度", "02"},
                {"MP30aToMP30b厚度", "02"},
                {"MP31aToMP31b厚度", "02"},
                {"MP32aToMP32b厚度", "02"},
                {"MP33aToMP33b厚度", "02"},
                {"MP34aToMP34b厚度", "02"},
                {"MP35aToMP35b厚度", "02"},
                {"MP36aToMP36b厚度", "02"},
                {"MP37aToMP37b厚度", "02"},
                {"MP38aToMP38b厚度", "02"},
                {"MP39aToMP39b厚度", "02"},
                {"MP8aToMP8b宽度", "02"},
                {"MP9aToMP9b宽度", "02"},
                {"MP10aToMP10b宽度", "02"},
                {"MP11aToMP11b宽度", "02"},
                {"M12PaToMP12b高度", "02"},
                {"MP13aToMP13b高度", "02"},
                {"MP14aToMP14b高度", "02"},
                {"MP15aToMP15b高度", "02"},
                {"MP16aToMP16b高度", "02"},
                {"MP17aToMP17b高度", "02"},
                {"MP18aToMP18b高度", "02"},
                {"MP19aToMP19b高度", "02"},
                {"MP20aToMP20b高度", "02"},
                {"MP21aToMP21b高度", "02"},
                {"MP22aToMP22b高度", "02"},
                {"MP23aToMP23b高度", "02"},
                {"MP24aToMP24b高度", "02"},
                {"MP25aToMP25b高度", "02"},
                {"MP26aToMP26b高度", "02"},
                {"MP27aToMP27b高度", "02"},
                {"MP28aToMP28b高度", "02"},
                {"MP29aToMP29b高度", "02"}
            };
            DB_Work.addToDB(keys);
        }
        /// <summary>
        /// 
        /// </summary>
        private void refreshDB(object sender,DataRowChangeEventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                mainBatterryDataGridView.DataSource = DB_Work.DB_Table;
            });
        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Vector3D[] vector3Ds = new Vector3D[10];
            //vector3Ds[0] = new Vector3D(1, 2, 9);
            //vector3Ds[1] = new Vector3D(4, 7, 30);
            //vector3Ds[2] = new Vector3D(5, 8, 35);
            //vector3Ds[3] = new Vector3D(3, 5, 22);
            //vector3Ds[4] = new Vector3D(6, 12, 49);
            //vector3Ds[5] = new Vector3D(10, 22, 70);
            //vector3Ds[6] = new Vector3D(42, 2, 91);
            //vector3Ds[7] = new Vector3D(41, 3, 92);
            //vector3Ds[8] = new Vector3D(52, 2, 111);
            //vector3Ds[9] = new Vector3D(54, 7, 20);
            //PlanePara tmp = Algorithm.getPlanePara(vector3Ds);
            //double angle = Algorithm.getPlaneToPlaneAngle(tmp, tmp);
            //MessageBox.Show(string.Format("平面参数(Kx:{0},Ky:{1},Kz:{2},B:{3},Flatness:{4}),夹角{5}", tmp.Kx,tmp.Ky,tmp.Kz,tmp.B,tmp.Flatness, angle));

            //ReadValue test = new ReadValue();
            //MessageBox.Show(string.Format("赋值前:({0},{1},{2})", test.Mp10a.X, test.Mp10a.Y, test.Mp10a.Z));
            //test.readValue();
            //MessageBox.Show(string.Format("赋值后:({0},{1},{2})", test.Mp10a.X, test.Mp10a.Y, test.Mp10a.Z));

            //WorkProcess.Variable = 1;

            //ReadValue test = new ReadValue();
            //PlaneResole planetest = new PlaneResole();
            //planetest.Mode79Point(test, planetest.Point7AList);

            //Parameter para = new Parameter();
            //para.BaudrateNo = 19200;
            //para.PortNo = 3;
            //para.Ip = "192.168.1.1";
            //OperatePara.SavePara("Para.cfg", para);
            //Parameter para1 = OperatePara.LoadPara("Para.cfg");
        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            OperatePara.SavePara("Para.cfg",SysPara);
        }
        /// <summary>
        /// 刷新串口列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_List_Click(object sender, EventArgs e)
        {
            Com_List.Items.Clear();
            CodeDevice.Refresh_Com_List();
            Com_List.Items.AddRange(CodeDevice.PortName.ToArray());
        }
        /// <summary>
        /// 手动打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Re_connect_Click(object sender, EventArgs e)
        {
            OpenCodeDevice();
        }
        /// <summary>
        /// 打开串口并刷新状态
        /// </summary>
        private void OpenCodeDevice()
        {
            if (CodeDevice.Open_Com(SysPara.PortNo, SysPara.BaudrateNo))
            {
                Com_Status.Image = Properties.Resources.Green;
                Re_connect.Text = "关闭串口";
            }
            else
            {
                Com_Status.Image = Properties.Resources.Red;
                Re_connect.Text = "打开串口";
            }
        }
        /// <summary>
        /// 修改串口号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            SysPara.PortNo = Com_List.SelectedIndex;
        }
        /// <summary>
        /// 判断OK/NG 禁用 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JudgeDisable_CheckedChanged(object sender, EventArgs e)
        {
            RefreshJudgeRadiobuton();
        }
        /// <summary>
        /// 判断OK/NG 启用 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void judgeEnable_CheckedChanged(object sender, EventArgs e)
        {
            RefreshJudgeRadiobuton();
        }
        /// <summary>
        /// RefreshJudgeRadiobuton
        /// </summary>
        private void RefreshJudgeRadiobuton()
        {
            SysPara.Judge = judgeEnable.Checked;
        }
        /// <summary>
        /// 接收条码枪条码并处理提取
        /// </summary>
        private void CodeResolve()
        {
            MessageBox.Show("接收成功！");

        }
        /// <summary>
        /// 权限判断
        /// </summary>
        /// <returns></returns>
        private bool getAuthority()
        {
            if (UserList.Contains(usmen))
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
        /// <summary>
        /// 正在切换页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectedPageChanging(object sender, TabFormSelectedPageChangingEventArgs e)
        {
            if (FirstSign && !(UserList == null) && !getAuthority())
            {
                if (!(e.Page == User_Tab_Form))
                {
                    e.Cancel = true;
                    this.TabControl.SelectedPage = this.TabControl.Pages[0];//跳转到登录页面
                    MessageBox.Show("请登录");
                }
            }
        }
        /// <summary>
        /// 自动追加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userListEdit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int numRows = e.RowIndex;//行索引
            int numColumns = e.ColumnIndex;//列索引
            List<string> contentsList = new List<string>();
            foreach (DataColumn o in DB_Operate.DB_Table.Columns)
            {
                contentsList.Add(o.ColumnName);
            }
            string[] contents = new string[contentsList.Count];
            string fields = null;
            string values = null;
            string newContents = this.userListEdit.Rows[numRows].Cells[numColumns].Value.ToString();
            int numNewContents = Array.IndexOf(UserList, newContents);
            string oldContents = null;
            if (numRows < DB_Operate.DB_Table.Rows.Count) oldContents = UserList[numRows];
            for (int i = 0; i < contents.Length; i++)
            {
                contents[i] = this.userListEdit.Rows[numRows].Cells[contentsList[i]].Value.ToString();
            }
            //数据库操作
            if (numRows >= DB_Operate.DB_Table.Rows.Count)//新增行
            {
                if (UserList.Contains(contents[0]))
                {
                    MessageBox.Show("用户名重复，禁止添加！！");
                    this.userListEdit.Rows.RemoveAt(numRows);
                }
                else
                {
                    if (!contents.Contains(""))//追加数据
                    {
                        for (int i = 0; i < contents.Length; i++)
                        {
                            fields += contentsList[i] + ",";
                            values += string.Format("'{0}'", contents[i]) + ",";
                        }
                        fields = fields.Remove(fields.Length - 1, 1);
                        values = values.Remove(values.Length - 1, 1);
                        DB_Operate.addToDB(fields, values);
                        getUserList();
                    }
                }
                
            }
            else//修改具体数据
            {
                if (numColumns == 0)//用户名列
                {
                    if (newContents == oldContents)
                    {
                        return;
                    }
                    else
                    {
                        if (numNewContents == numRows)//修改值在
                        {
                            return;
                        }
                        else
                        {
                            if (numNewContents >= 0)
                            {
                                MessageBox.Show("用户名重复，禁止修改！！");
                                this.userListEdit.Rows[numRows].Cells[numColumns].Value = oldContents;
                                return;
                            }
                            else
                            {
                                DB_Operate.updateDB(contentsList[numColumns], newContents, oldContents);
                                getUserList();
                            }

                        }
                    }
                }
                else
                {
                    if (newContents == oldContents)
                    {
                        return;
                    }
                    else
                    {
                        if (numNewContents == numRows)//修改值在
                        {
                            return;
                        }
                        else
                        {
                            DB_Operate.updateDB(contentsList[numColumns], newContents, oldContents);
                        }
                    }
                }

            }            
        }
        /// <summary>
        /// 回车登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            int numRows = this.userListEdit.CurrentRow.Index;//当前选定行
            List<string> contentsList = new List<string>();
            string fields = null;
            string values = null;
            fields = DB_Operate.DB_Table.Columns[0].ColumnName;
            values = string.Format("'{0}'", this.userListEdit.Rows[numRows].Cells[0].Value.ToString());
            DB_Operate.deleteDB(fields,values);
            getUserList();
            this.userListEdit.Rows.RemoveAt(numRows);
        }
        /// <summary>
        /// 同步数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainBatterryDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DB_Work.UpdateByDt(dtTemp);
        }
        /// <summary>
        /// Main data grid view 初始化
        /// </summary>
        private void InitialData()
        {
            cRows = DB_Work.DB_Table.Rows.Count;
            cPages = cRows % SysPara.PageSize == 0 ? cRows / SysPara.PageSize : cRows / SysPara.PageSize + 1;
            PageCurrent = 1;
            toolStripTextBox1.Text = SysPara.PageSize.ToString();
            LoadData();
        }
        /// <summary>
        /// 数据
        /// </summary>
        private void LoadData()
        {
            if (PageCurrent == 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorMoveFirstItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorMoveFirstItem.Enabled =true;
            }
            if (cPages == PageCurrent)
            {
                bindingNavigatorMoveNextItem.Enabled = false;
                bindingNavigatorMoveLastItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;
            }
            bindingNavigatorPositionItem.Text = PageCurrent.ToString();
            bindingNavigatorCountItem.Text = cPages.ToString();
            int startRow = (PageCurrent - 1) * SysPara.PageSize;
            int endRow = PageCurrent == cPages ? cRows : PageCurrent * SysPara.PageSize;
            dtTemp = DB_Work.DB_Table.Clone();
            if (DB_Work.DB_Table.Rows.Count != 0)
            {
                for (int i = startRow; i < endRow; i++)
                {
                    dtTemp.ImportRow(DB_Work.DB_Table.Rows[i]);
                }
                bindingSource1.DataSource = dtTemp;
                mainBatterryDataGridView.DataSource = bindingSource1;
            }
        }
        /// <summary>
        /// 移动到第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            PageCurrent = 1;
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = true;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = true;
            LoadData();
        }
        /// <summary>
        /// 移动到最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            PageCurrent = cPages;
            bindingNavigatorMoveFirstItem.Enabled = true;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = true;
            bindingNavigatorMoveLastItem.Enabled = false;
            LoadData();
        }
        /// <summary>
        /// 直接定位到某一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(bindingNavigatorPositionItem.Text) > 0 && Convert.ToInt32(bindingNavigatorPositionItem.Text) <= cPages)
                {
                    PageCurrent = Convert.ToInt32(bindingNavigatorPositionItem.Text);
                    LoadData();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (System.Exception ex)
            {
                PageCurrent = 1;
                LoadData();
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorMoveNextItem.Enabled = true;
            if (PageCurrent == 1)
            {
                bindingNavigatorMovePreviousItem.Enabled = false;
                MessageBox.Show("已经是第一页了");
                return;
            }
            PageCurrent--;
            LoadData();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindingNavigatorMovePreviousItem.Enabled = true;
            if (PageCurrent == SysPara.PageSize)
            {
                bindingNavigatorMoveNextItem.Enabled = false;
                MessageBox.Show("已经是最后一页了");
                return;
            }
            PageCurrent++;
            LoadData();
        }
        /// <summary>
        /// 修改每页显示数目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(toolStripTextBox1.Text,out int tmp))
            {
                SysPara.PageSize = tmp;
                InitialData();
            }
            else
            {
                MessageBox.Show("格式错误！！");
            }
        }
    }
}
