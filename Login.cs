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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Role");
            }
            if (RoleCb.SelectedItem.ToString() == "Admin")
            {
                Employees emp = new Employees();
                emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Admin Name or Password");
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ResetLbl_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }
    }
}
