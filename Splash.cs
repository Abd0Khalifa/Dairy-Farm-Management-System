using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairy_Farm_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int startppoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startppoint += 1;
            MyProgress.Value = startppoint;
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                Login Log = new Login();
                this.Hide();
                Log.Show();
            }
        }
    }
}
