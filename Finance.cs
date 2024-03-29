﻿using System;
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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            populate();
            Incpopulate();
            FillEmpId();
        }

        SqlConnection con = new SqlConnection(@"Data Source=
        (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\defds\Documents\DailyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clearExp()
        {
            PurbCb.SelectedIndex = -1;
            AmountTb.Text = "";
        }
        private void Incpopulate()
        {
            con.Open();
            string Query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FilterIncome()
        {
            con.Open();
            string Query = "select * from IncomeTbl where IncDate='"+IncDateFilter.Value.Date+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FilterExp()
        {
            con.Open();
            string Query = "select * from ExpenditureTbl where ExpDate='" + ExpDateFilter.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clearInc()
        {
            IncPurpCb.SelectedIndex = -1;
            AmountTb.Text = "";
        }
        private void FillEmpId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpIdCb", typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpId";
            EmpIdCb.DataSource = dt;
            con.Close();
        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            Cows obj = new Cows();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MilkProduction obj = new MilkProduction();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            CowHealth obj = new CowHealth();
            obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Breedings obj = new Breedings();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MilkSales obj = new MilkSales();
            obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Finance obj = new Finance();
            obj.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void ExpSaveBtn_Click(object sender, EventArgs e)
        {
            if (PurbCb.SelectedIndex == -1 || AmountTb.Text == ""||EmpIdCb.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into ExpenditureTbl values('" + ExpDate.Value.Date + "','" + PurbCb.SelectedItem.ToString() + "'," + AmountTb.Text + "," + EmpIdCb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Saved");
                    con.Close();
                    populate();
                    clearExp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void IncSaveBtn_Click(object sender, EventArgs e)
        {
            if (IncPurpCb.SelectedIndex == -1 || IncAmountTb.Text == ""||EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into IncomeTbl values('" + IncDate.Value.Date + "','" + IncPurpCb.SelectedItem.ToString() + "'," + IncAmountTb.Text + "," + EmpIdCb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Saved");
                    con.Close();
                    Incpopulate();
                    clearInc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void IncDateFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterIncome();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Incpopulate();
        }

        private void ExpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterExp();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void Finance_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
