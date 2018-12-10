using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DG_Measure
{
    public delegate void Change_Event();
    class ValueChange
    {   
        public delegate void Change_Event();
        public event Change_Event equal1Event;//==1触发事件  
        public event Change_Event equal1ClearEvent;//==1触发清空事件 
        private int variable;
        public Int32 Variable
        {
            get
            {
                return variable;
            }
            set
            {
                if (value == 1)
                {
                    variable = 0;
                    equal1ClearEvent?.Invoke();
                    Thread.Sleep(200);//延迟200ms
                    equal1Event?.Invoke();                   
                }
            }
        }
    }
}
