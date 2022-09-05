using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Intern
{
    public partial class Calculations : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C8I030MT;Initial Catalog=StudentDB;Integrated Security=True");
        


        public Calculations()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string u_Search = txtSearch.Text;
                string Query_search = "select * from Teacher where RegNo='" + u_Search + "'";
                SqlCommand cmd = new SqlCommand(Query_search, con);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    txtName.Text = r[1].ToString();
                    txtDay.Text = r[6].ToString();
                    string bs = r[7].ToString();
                    int s;
                    if(bs== "Principle (level 1)")
                    {
                        s = 25000;
                    }else if(bs== "Principle (level 2)")
                    {
                        s = 20000;
                    }else if(bs=="Teacher (level 1)")
                    {
                        s = 15000;
                    }
                    else
                    {
                        s = 10000;
                    }
                    txtBsalary.Text = s.ToString();
                    int d = int.Parse(r[6].ToString());
                    int nt = s + d * 750;
                    txtNsalary.Text = nt.ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error while Searching" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtDay.Text = string.Empty;
            txtBsalary.Text = string.Empty;
            txtNsalary.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        private void btnMainmenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu obj5 = new MainMenu();
            obj5.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
