using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentWindowsApp
{
    public partial class frmBrokenRules : Form
    {
        public frmBrokenRules()
        {
            InitializeComponent();
        }

        public object BrokenRules
        {
            set
            {
                gvBrokenRules.DataSource = value;
            }
        }
    }
}
