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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-008QT07;Initial Catalog=ATMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void getBalance()
        {
            
            Con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select Balance from AccountTB where AccNum ='"+AccNum.Text+"'",Con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            BalanceinRs.Text = dt.Rows[0][0].ToString();
            Con.Close(); 

        }
        private void Balance_Load(object sender, EventArgs e)
        {
            AccNum.Text = Login.AccNumber;
            getBalance();
        }

        private void BalanceinRs_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
