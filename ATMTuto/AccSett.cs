using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATMTuto
{
    public partial class AccSett : Form
    {
        public AccSett()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-008QT07;Initial Catalog=ATMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void getBalance()
        {

            Con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select Balance from AccountTB where AccNum ='" +Acc.Text + "'", Con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            Bal.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void pin()
        {
            Con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select Pin from AccountTB where AccNum = '" + Acc.Text + "'", Con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            Fpin.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void AccSett_Load(object sender, EventArgs e)
        {
            Acc.Text = Login.AccNumber;
            getBalance();
            pin();
        }

        private void AccSette_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "Delete from AccountTB where AccNum = "+Acc.Text+"";
                SqlCommand cmd = new SqlCommand(query,Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Deleted Successfully");
                Con.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
    }
}
