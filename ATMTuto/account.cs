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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-008QT07;Initial Catalog=ATMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNumTB.Text == "" || NameTB.Text == "" || FnameTB.Text == "" || PhoneTB.Text == "" || AddressTB.Text == "" || PinTB.Text == "" || EducationTB.Text == "" || OccupationTB.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTB values ('" + AccNumTB.Text + "','" + NameTB.Text + "','" + FnameTB.Text + "','" + dobdate.Value.Date + "','" + PhoneTB.Text + "','" + AddressTB.Text + "','" + EducationTB.SelectedItem.ToString() + "','" + OccupationTB.Text + "','"+bal+"','"+PinTB.Text+"')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Creted Successfully");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void account_Load(object sender, EventArgs e)
        {

        }

        private void PhoneTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
