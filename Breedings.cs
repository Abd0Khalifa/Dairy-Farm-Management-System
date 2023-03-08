using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dairy_Farm_Management_System
{
    public partial class Breedings : Form
    {
        public Breedings()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        SqlConnection con = new SqlConnection(@"Data Source=
        (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\defds\Documents\DailyFarmDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillCowId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string Query = "select * from BreedTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedingDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void GetCowName()
        {
            con.Open();
            String query = "select * from CowTbl where CowId=" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();
                CowAgeTb.Text = dr["Age"].ToString();
            }

            con.Close();
        }
        private void Clear()
        {
            CowIdCb.SelectedIndex = -1;
            CowNameTb.Text = "";
            CowAgeTb.Text = "";
            RemarkesTb.Text = "";
            key = 0;
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

        private void Breedings_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || CowAgeTb.Text == "" || RemarkesTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into BreedTbl values('" + HeatDate.Value.Date + "','" + BreedDate.Value.Date + "','" + CowIdCb.SelectedValue.ToString() + "','" + CowNameTb.Text + "','" + PregancyDate.Value.Date + "','" + ExcpectedDate.Value.Date + "', '" + CalvedDate.Value.Date + "', '" + CowAgeTb.Text + "', '" + RemarkesTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed saved");
                    con.Close();
                    populate();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        int key = 0;
        private void BreedingDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = BreedingDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = BreedingDGV.SelectedRows[0].Cells[2].Value.ToString();
            HeatDate.Text = BreedingDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedDate.Text = BreedingDGV.SelectedRows[0].Cells[4].Value.ToString();
            PregancyDate.Text = BreedingDGV.SelectedRows[0].Cells[5].Value.ToString();
            ExcpectedDate.Text = BreedingDGV.SelectedRows[0].Cells[6].Value.ToString();
            CalvedDate.Text = BreedingDGV.SelectedRows[0].Cells[7].Value.ToString();
            RemarkesTb.Text = BreedingDGV.SelectedRows[0].Cells[7].Value.ToString();
            
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
