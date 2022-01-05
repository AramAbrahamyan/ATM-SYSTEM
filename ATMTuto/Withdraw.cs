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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-008QT07;Initial Catalog=ATMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string AccNumber = Login.AccNumber;
        int  newbalance,bal;

        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter adapte = new SqlDataAdapter("Select Balance from AccountTB where AccNum ='" + AccNumber + "'", Con);
            DataTable dt = new DataTable();
            adapte.Fill(dt);
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Wd.Text == "")
            {
                MessageBox.Show("Missing Information:\nPlease check and try again.");
            }
            else if (Int32.Parse(Wd.Text) <= 0)
            {
                MessageBox.Show("Please enter valid sum");
            }
            else if (Int32.Parse(Wd.Text) > bal)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - Int32.Parse(Wd.Text);
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Withdraw");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
