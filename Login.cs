using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection con = new SqlConnection(@"Data Source=
        (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\defds\Documents\DailyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter UserName And Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (UnameTb.Text == "Admin" || PasswordTb.Text == "Admin")
                        {
                            Employees emp = new Employees();
                            emp.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If You are Admin, Enter The Correct Id and Password");
                        }
                    }
                    else
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "'and EmpPass='" + PasswordTb.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Cows cow = new Cows();
                            cow.Show();
                            this.Hide();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select Role");
                }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
