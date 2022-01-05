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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-008QT07;Initial Catalog=ATMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string AccNumber = Login.AccNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            if (DepoAmTB.Text == "" || Int32.Parse(DepoAmTB.Text) < 0)
            {
                MessageBox.Show("Enter The Amount To Deposit");
            }
            else
            {
                newbalance = oldbalance + Int32.Parse(DepoAmTB.Text);
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTB SET Balance = "+ newbalance + " WHERE AccNum = " +AccNumber+ "";
                    SqlCommand cmd = new SqlCommand(query,Con);
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

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int oldbalance, newbalance;
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter adapte = new SqlDataAdapter("Select Balance from AccountTB where AccNum ='" + AccNumber+ "'", Con);
            DataTable dt = new DataTable();
            adapte.Fill(dt);
            oldbalance = Int32.Parse(dt.Rows[0][0].ToString());
            Con.Close();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            getBalance();
        }
    }
}
