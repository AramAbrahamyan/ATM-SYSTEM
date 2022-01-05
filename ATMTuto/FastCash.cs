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
    public partial class FastCash : Form
    {
        public FastCash()
        {
            InitializeComponent();
        }

        private void FastCash_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-008QT07;Initial Catalog=ATMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static string AccNumber = Login.AccNumber;
        public int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter adapte = new SqlDataAdapter("Select Balance from AccountTB where AccNum ='" + AccNumber + "'", Con);
            DataTable dt = new DataTable();
            adapte.Fill(dt);
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        int newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(bal < 100)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - 500;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 5000)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - 5000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 10000)
            {
                MessageBox.Show("Balance can't be negative");
            }
            else
            {
                newbalance = bal - 10000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = " + newbalance + " WHERE AccNum = " + AccNumber + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
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
    }
}
