using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StateManager;
using System.Threading;

namespace Demo.Logics
{
    public partial class type2 : Form,ILogic
    {
        public type2()
        {
            InitializeComponent();
        }
        public void HandleState(SObject so)
        {
            switch (so.State)
            {
                case "":
                    break;
            }
        }

        public void Init(SObject so)
        {

        }

        public void FInit(SObject so)
        {

        }
    }
}
