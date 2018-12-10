namespace DG_Measure
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            if (--OpenFormCount == 0) System.Windows.Forms.Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.TabControl = new DevExpress.XtraBars.TabFormControl();
            this.barHeaderUser = new DevExpress.XtraBars.BarHeaderItem();
            this.plcStatusButton = new DevExpress.XtraBars.BarButtonItem();
            this.User_Tab_Form = new DevExpress.XtraBars.TabFormPage();
            this.User_Tab_Form_Container = new DevExpress.XtraBars.TabFormContentContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Confirm_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Password_Input = new DevExpress.XtraEditors.TextEdit();
            this.User_List = new DevExpress.XtraEditors.ComboBoxEdit();
            this.User_Password = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.User_Name = new DevExpress.XtraEditors.LabelControl();
            this.Main_Tab_Form = new DevExpress.XtraBars.TabFormPage();
            this.Main_Tab_Form_Container = new DevExpress.XtraBars.TabFormContentContainer();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.mainBatterryDataGridView = new System.Windows.Forms.DataGridView();
            this.Set_Tab_Form = new DevExpress.XtraBars.TabFormPage();
            this.Set_Tab_Form_Container = new DevExpress.XtraBars.TabFormContentContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DeleteUser = new System.Windows.Forms.Button();
            this.userListEdit = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.JudgeDisable = new System.Windows.Forms.RadioButton();
            this.judgeEnable = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Refresh_List = new System.Windows.Forms.Button();
            this.Com_Status = new System.Windows.Forms.PictureBox();
            this.Re_connect = new System.Windows.Forms.Button();
            this.Com_List = new System.Windows.Forms.ComboBox();
            this.Information_Tab_Form = new DevExpress.XtraBars.TabFormPage();
            this.Info_Tab_Form_Container = new DevExpress.XtraBars.TabFormContentContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.User_Tab_Form_Container.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Input.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_List.Properties)).BeginInit();
            this.Main_Tab_Form_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBatterryDataGridView)).BeginInit();
            this.Set_Tab_Form_Container.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userListEdit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Com_Status)).BeginInit();
            this.Info_Tab_Form_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.AllowMoveTabs = false;
            this.TabControl.AllowMoveTabsToOuterForm = false;
            this.TabControl.AllowTabAnimation = false;
            this.TabControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barHeaderUser,
            this.plcStatusButton});
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(5);
            this.TabControl.Name = "TabControl";
            this.TabControl.Pages.Add(this.User_Tab_Form);
            this.TabControl.Pages.Add(this.Main_Tab_Form);
            this.TabControl.Pages.Add(this.Set_Tab_Form);
            this.TabControl.Pages.Add(this.Information_Tab_Form);
            this.TabControl.SelectedPage = this.Main_Tab_Form;
            this.TabControl.ShowAddPageButton = false;
            this.TabControl.ShowTabCloseButtons = false;
            this.TabControl.Size = new System.Drawing.Size(1910, 70);
            this.TabControl.TabForm = this;
            this.TabControl.TabIndex = 0;
            this.TabControl.TabLeftItemLinks.Add(this.plcStatusButton);
            this.TabControl.TabRightItemLinks.Add(this.barHeaderUser);
            this.TabControl.TabStop = false;
            this.TabControl.SelectedPageChanging += new DevExpress.XtraBars.TabFormSelectedPageChangingEventHandler(this.TabControl_SelectedPageChanging);
            this.TabControl.OuterFormCreating += new DevExpress.XtraBars.OuterFormCreatingEventHandler(this.OnOuterFormCreating);
            // 
            // barHeaderUser
            // 
            this.barHeaderUser.Appearance.BackColor = System.Drawing.SystemColors.Menu;
            this.barHeaderUser.Appearance.ForeColor = System.Drawing.Color.LimeGreen;
            this.barHeaderUser.Appearance.Options.UseBackColor = true;
            this.barHeaderUser.Appearance.Options.UseForeColor = true;
            this.barHeaderUser.Id = 4;
            this.barHeaderUser.Name = "barHeaderUser";
            // 
            // plcStatusButton
            // 
            this.plcStatusButton.Id = 6;
            this.plcStatusButton.Name = "plcStatusButton";
            // 
            // User_Tab_Form
            // 
            this.User_Tab_Form.ContentContainer = this.User_Tab_Form_Container;
            this.User_Tab_Form.Name = "User_Tab_Form";
            this.User_Tab_Form.Text = "用户";
            // 
            // User_Tab_Form_Container
            // 
            this.User_Tab_Form_Container.Controls.Add(this.groupBox1);
            this.User_Tab_Form_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User_Tab_Form_Container.Location = new System.Drawing.Point(0, 70);
            this.User_Tab_Form_Container.Name = "User_Tab_Form_Container";
            this.User_Tab_Form_Container.Size = new System.Drawing.Size(1910, 1005);
            this.User_Tab_Form_Container.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Cancel_Button);
            this.groupBox1.Controls.Add(this.Confirm_Button);
            this.groupBox1.Controls.Add(this.Password_Input);
            this.groupBox1.Controls.Add(this.User_List);
            this.groupBox1.Controls.Add(this.User_Password);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.User_Name);
            this.groupBox1.Location = new System.Drawing.Point(633, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 409);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Button.Appearance.Options.UseFont = true;
            this.Cancel_Button.Location = new System.Drawing.Point(397, 302);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(165, 56);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "取  消";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Confirm_Button
            // 
            this.Confirm_Button.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm_Button.Appearance.Options.UseFont = true;
            this.Confirm_Button.Location = new System.Drawing.Point(86, 302);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.Size = new System.Drawing.Size(165, 56);
            this.Confirm_Button.TabIndex = 4;
            this.Confirm_Button.Text = "确  定";
            this.Confirm_Button.Click += new System.EventHandler(this.Confirm_Button_Click);
            // 
            // Password_Input
            // 
            this.Password_Input.Location = new System.Drawing.Point(283, 189);
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Input.Properties.Appearance.Options.UseFont = true;
            this.Password_Input.Properties.PasswordChar = '*';
            this.Password_Input.Size = new System.Drawing.Size(221, 48);
            this.Password_Input.TabIndex = 3;
            this.Password_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_Input_KeyDown);
            // 
            // User_List
            // 
            this.User_List.Location = new System.Drawing.Point(283, 71);
            this.User_List.Name = "User_List";
            this.User_List.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_List.Properties.Appearance.Options.UseFont = true;
            this.User_List.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.User_List.Properties.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.User_List.Size = new System.Drawing.Size(221, 42);
            this.User_List.TabIndex = 2;
            // 
            // User_Password
            // 
            this.User_Password.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Password.Appearance.Options.UseFont = true;
            this.User_Password.Location = new System.Drawing.Point(132, 189);
            this.User_Password.Name = "User_Password";
            this.User_Password.Size = new System.Drawing.Size(132, 48);
            this.User_Password.TabIndex = 1;
            this.User_Password.Text = "密    码";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(132, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(145, 48);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用    户 ";
            // 
            // User_Name
            // 
            this.User_Name.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Name.Appearance.Options.UseFont = true;
            this.User_Name.Location = new System.Drawing.Point(132, 71);
            this.User_Name.Name = "User_Name";
            this.User_Name.Size = new System.Drawing.Size(145, 48);
            this.User_Name.TabIndex = 0;
            this.User_Name.Text = "用    户 ";
            // 
            // Main_Tab_Form
            // 
            this.Main_Tab_Form.ContentContainer = this.Main_Tab_Form_Container;
            this.Main_Tab_Form.Name = "Main_Tab_Form";
            this.Main_Tab_Form.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.Main_Tab_Form.Text = "主页";
            // 
            // Main_Tab_Form_Container
            // 
            this.Main_Tab_Form_Container.Controls.Add(this.bindingNavigator1);
            this.Main_Tab_Form_Container.Controls.Add(this.mainBatterryDataGridView);
            this.Main_Tab_Form_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Tab_Form_Container.Location = new System.Drawing.Point(0, 70);
            this.Main_Tab_Form_Container.Margin = new System.Windows.Forms.Padding(5);
            this.Main_Tab_Form_Container.Name = "Main_Tab_Form_Container";
            this.Main_Tab_Form_Container.Size = new System.Drawing.Size(1910, 1005);
            this.Main_Tab_Form_Container.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 974);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1910, 31);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 28);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            this.bindingNavigatorPositionItem.TextChanged += new System.EventHandler(this.bindingNavigatorPositionItem_TextChanged);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 28);
            this.toolStripLabel1.Text = "每页数目";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 31);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // mainBatterryDataGridView
            // 
            this.mainBatterryDataGridView.AllowUserToAddRows = false;
            this.mainBatterryDataGridView.AllowUserToDeleteRows = false;
            this.mainBatterryDataGridView.AllowUserToResizeColumns = false;
            this.mainBatterryDataGridView.AllowUserToResizeRows = false;
            this.mainBatterryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainBatterryDataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.mainBatterryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainBatterryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mainBatterryDataGridView.Cursor = System.Windows.Forms.Cursors.No;
            this.mainBatterryDataGridView.Location = new System.Drawing.Point(12, 8);
            this.mainBatterryDataGridView.Name = "mainBatterryDataGridView";
            this.mainBatterryDataGridView.RowTemplate.Height = 30;
            this.mainBatterryDataGridView.Size = new System.Drawing.Size(1886, 949);
            this.mainBatterryDataGridView.TabIndex = 0;
            this.mainBatterryDataGridView.VirtualMode = true;
            this.mainBatterryDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainBatterryDataGridView_CellValidated);
            // 
            // Set_Tab_Form
            // 
            this.Set_Tab_Form.ContentContainer = this.Set_Tab_Form_Container;
            this.Set_Tab_Form.Name = "Set_Tab_Form";
            this.Set_Tab_Form.Text = "设置";
            // 
            // Set_Tab_Form_Container
            // 
            this.Set_Tab_Form_Container.Controls.Add(this.groupBox4);
            this.Set_Tab_Form_Container.Controls.Add(this.groupBox3);
            this.Set_Tab_Form_Container.Controls.Add(this.groupBox2);
            this.Set_Tab_Form_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Set_Tab_Form_Container.Location = new System.Drawing.Point(0, 70);
            this.Set_Tab_Form_Container.Name = "Set_Tab_Form_Container";
            this.Set_Tab_Form_Container.Size = new System.Drawing.Size(1910, 1005);
            this.Set_Tab_Form_Container.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DeleteUser);
            this.groupBox4.Controls.Add(this.userListEdit);
            this.groupBox4.Location = new System.Drawing.Point(34, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(554, 501);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户管理";
            // 
            // DeleteUser
            // 
            this.DeleteUser.Location = new System.Drawing.Point(409, 54);
            this.DeleteUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteUser.Name = "DeleteUser";
            this.DeleteUser.Size = new System.Drawing.Size(122, 35);
            this.DeleteUser.TabIndex = 34;
            this.DeleteUser.Text = "删除用户";
            this.DeleteUser.UseVisualStyleBackColor = true;
            this.DeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // userListEdit
            // 
            this.userListEdit.AllowUserToDeleteRows = false;
            this.userListEdit.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.userListEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userListEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.userListEdit.Location = new System.Drawing.Point(23, 46);
            this.userListEdit.Name = "userListEdit";
            this.userListEdit.RowHeadersVisible = false;
            this.userListEdit.RowTemplate.Height = 30;
            this.userListEdit.ShowCellToolTips = false;
            this.userListEdit.Size = new System.Drawing.Size(359, 432);
            this.userListEdit.TabIndex = 0;
            this.userListEdit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.userListEdit_CellEndEdit);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.JudgeDisable);
            this.groupBox3.Controls.Add(this.judgeEnable);
            this.groupBox3.Location = new System.Drawing.Point(29, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 96);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "判断OK/NG";
            // 
            // JudgeDisable
            // 
            this.JudgeDisable.AutoSize = true;
            this.JudgeDisable.Location = new System.Drawing.Point(440, 46);
            this.JudgeDisable.Name = "JudgeDisable";
            this.JudgeDisable.Size = new System.Drawing.Size(69, 22);
            this.JudgeDisable.TabIndex = 2;
            this.JudgeDisable.TabStop = true;
            this.JudgeDisable.Text = "禁用";
            this.JudgeDisable.UseVisualStyleBackColor = true;
            this.JudgeDisable.CheckedChanged += new System.EventHandler(this.JudgeDisable_CheckedChanged);
            // 
            // judgeEnable
            // 
            this.judgeEnable.AutoSize = true;
            this.judgeEnable.Location = new System.Drawing.Point(46, 46);
            this.judgeEnable.Name = "judgeEnable";
            this.judgeEnable.Size = new System.Drawing.Size(69, 22);
            this.judgeEnable.TabIndex = 1;
            this.judgeEnable.TabStop = true;
            this.judgeEnable.Text = "启用";
            this.judgeEnable.UseVisualStyleBackColor = true;
            this.judgeEnable.CheckedChanged += new System.EventHandler(this.judgeEnable_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Refresh_List);
            this.groupBox2.Controls.Add(this.Com_Status);
            this.groupBox2.Controls.Add(this.Re_connect);
            this.groupBox2.Controls.Add(this.Com_List);
            this.groupBox2.Location = new System.Drawing.Point(29, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 96);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "扫码器";
            // 
            // Refresh_List
            // 
            this.Refresh_List.Location = new System.Drawing.Point(28, 38);
            this.Refresh_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Refresh_List.Name = "Refresh_List";
            this.Refresh_List.Size = new System.Drawing.Size(122, 35);
            this.Refresh_List.TabIndex = 33;
            this.Refresh_List.Text = "更新列表";
            this.Refresh_List.UseVisualStyleBackColor = true;
            this.Refresh_List.Click += new System.EventHandler(this.Refresh_List_Click);
            // 
            // Com_Status
            // 
            this.Com_Status.Location = new System.Drawing.Point(480, 31);
            this.Com_Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Com_Status.Name = "Com_Status";
            this.Com_Status.Size = new System.Drawing.Size(48, 48);
            this.Com_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Com_Status.TabIndex = 32;
            this.Com_Status.TabStop = false;
            // 
            // Re_connect
            // 
            this.Re_connect.Location = new System.Drawing.Point(329, 38);
            this.Re_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Re_connect.Name = "Re_connect";
            this.Re_connect.Size = new System.Drawing.Size(122, 35);
            this.Re_connect.TabIndex = 30;
            this.Re_connect.Text = "打开串口";
            this.Re_connect.UseVisualStyleBackColor = true;
            this.Re_connect.Click += new System.EventHandler(this.Re_connect_Click);
            // 
            // Com_List
            // 
            this.Com_List.FormattingEnabled = true;
            this.Com_List.Location = new System.Drawing.Point(179, 40);
            this.Com_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Com_List.Name = "Com_List";
            this.Com_List.Size = new System.Drawing.Size(121, 26);
            this.Com_List.TabIndex = 31;
            this.Com_List.SelectedIndexChanged += new System.EventHandler(this.Com_List_SelectedIndexChanged);
            // 
            // Information_Tab_Form
            // 
            this.Information_Tab_Form.ContentContainer = this.Info_Tab_Form_Container;
            this.Information_Tab_Form.Name = "Information_Tab_Form";
            this.Information_Tab_Form.Text = "关于";
            // 
            // Info_Tab_Form_Container
            // 
            this.Info_Tab_Form_Container.Controls.Add(this.button1);
            this.Info_Tab_Form_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info_Tab_Form_Container.Location = new System.Drawing.Point(0, 70);
            this.Info_Tab_Form_Container.Name = "Info_Tab_Form_Container";
            this.Info_Tab_Form_Container.Size = new System.Drawing.Size(1910, 1005);
            this.Info_Tab_Form_Container.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(311, 166);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 70);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlTop.Size = new System.Drawing.Size(1910, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1075);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlBottom.Size = new System.Drawing.Size(1910, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 70);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1005);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1910, 70);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1005);
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(null, false, this.TabControl)});
            this.mvvmContext1.ViewModelType = typeof(DG_Measure.MainViewModel);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 1075);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.Main_Tab_Form_Container);
            this.Controls.Add(this.TabControl);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainView";
            this.TabFormControl = this.TabControl;
            this.Text = "尺寸测量机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.User_Tab_Form_Container.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Input.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_List.Properties)).EndInit();
            this.Main_Tab_Form_Container.ResumeLayout(false);
            this.Main_Tab_Form_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBatterryDataGridView)).EndInit();
            this.Set_Tab_Form_Container.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userListEdit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Com_Status)).EndInit();
            this.Info_Tab_Form_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.TabFormContentContainer Main_Tab_Form_Container;
        private DevExpress.XtraBars.TabFormPage Main_Tab_Form;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.TabFormContentContainer Info_Tab_Form_Container;
        private DevExpress.XtraBars.TabFormPage User_Tab_Form;
        private DevExpress.XtraBars.TabFormPage Set_Tab_Form;
        private DevExpress.XtraBars.TabFormContentContainer Set_Tab_Form_Container;
        private DevExpress.XtraBars.TabFormPage Information_Tab_Form;
        private System.Windows.Forms.DataGridView mainBatterryDataGridView;
        private DevExpress.XtraBars.BarHeaderItem barHeaderUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraBars.BarButtonItem plcStatusButton;
        private System.Windows.Forms.Button Refresh_List;
        private System.Windows.Forms.PictureBox Com_Status;
        private System.Windows.Forms.Button Re_connect;
        private System.Windows.Forms.ComboBox Com_List;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton JudgeDisable;
        private System.Windows.Forms.RadioButton judgeEnable;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView userListEdit;
        private System.Windows.Forms.Button DeleteUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton Confirm_Button;
        private DevExpress.XtraEditors.TextEdit Password_Input;
        private DevExpress.XtraEditors.ComboBoxEdit User_List;
        private DevExpress.XtraEditors.LabelControl User_Password;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl User_Name;
        private DevExpress.XtraBars.TabFormContentContainer User_Tab_Form_Container;
        public DevExpress.XtraBars.TabFormControl TabControl;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

