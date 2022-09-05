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
    public partial class Student : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C8I030MT;Initial Catalog=StudentDB;Integrated Security=True");
        SqlDataAdapter da;

        public void tableloard()
        {
            con.Open();
            da = new SqlDataAdapter("select * from Student ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
        public Student()
        {
            InitializeComponent();
            tableloard();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtname.Text;
                string email = txtemail.Text;
                int tel = int.Parse(txtTp.Text);
                string gender;
                if (rbmale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string grade = cmbgrade.Text;

                string query_insert = "insert into Student values('" + fname + "','" + email + "','" + tel + "','" + gender + "','" + grade + "')";
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully ..!!");
                
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error While Saving" + ex);

            }
            tableloard();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtname.Text;
                string email = txtemail.Text;
                int tel = int.Parse(txtTp.Text);
                string gender;
                if (rbmale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string grade = cmbgrade.Text;
                string sqlupdate = "update Student set firstName='" + fname + "',email='" + email + "',tp='" + tel + "',gender='" + gender + "',grade='" + grade + "' where email='" + email + "'";
                SqlCommand cmd2 = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Update successfully.....!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while updating " + ex);
            }
            finally
            {
                con.Close();
            }tableloard();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtname.Text;
                string email = txtemail.Text;
                int tel = int.Parse(txtTp.Text);
                string gender;
                if (rbmale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string grade = cmbgrade.Text;
                string sqldelete = "delete from Student where email='"+email+"'";
                SqlCommand cmd3 = new SqlCommand(sqldelete, con);
                con.Open();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Delete successfully.....!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while deleting " + ex);
            }
            finally
            {
                con.Close();
            }tableloard();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string u_email = txtsearch.Text;
                string query_search = "select * from Student where email='" + u_email + "'";
                SqlCommand cmd4 = new SqlCommand(query_search, con);
                con.Open();
                SqlDataReader r = cmd4.ExecuteReader();
                while (r.Read())
                {
                    txtname.Text = r[1].ToString();
                    txtemail.Text = r[2].ToString();
                    txtTp.Text = r[3].ToString();
                    string gen = r[4].ToString();
                    if (gen == "Male")
                    {
                        rbmale.Checked = true;
                    }
                    else
                    {
                        rbfemale.Checked = true;
                    }
                    cmbgrade.Text = r[5].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error with search " + ex);
            }
            finally
            {
                con.Close();
            }tableloard();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtTp.Text = string.Empty;
            txtsearch.Text = string.Empty;
            cmbgrade.Text = string.Empty;
            rbmale.Checked = false;
            rbfemale.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu obj = new MainMenu();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
