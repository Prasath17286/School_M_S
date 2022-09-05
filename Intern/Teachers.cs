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
    public partial class Teachers : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C8I030MT;Initial Catalog=StudentDB;Integrated Security=True");
        SqlDataAdapter da;

        public void tableLoard()
        {
            con.Open();
            da = new SqlDataAdapter("select * from Teacher ", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;

        }
        public Teachers()
        {
            InitializeComponent();
            tableLoard();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text;
                string regno = txtrn.Text;
                string email = txtemail.Text;
                int tp = int.Parse(txttp.Text);
                string gender;
                if (rbmale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                int day = int.Parse(txtday.Text);
                string level = cmblevel.Text;

                string query_Insert = "insert into Teacher values('" + name + "','" + regno + "','" + email + "','" + tp + "','" + gender + "','"+day+"','" + level + "')";
                SqlCommand cmd = new SqlCommand(query_Insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved successfully....!!");
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while saving...!!" + ex);
            }tableLoard();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text;
                string regno = txtrn.Text;
                string email = txtemail.Text;
                int tp = int.Parse(txttp.Text);
                string gender;
                if (rbmale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                int day = int.Parse(txtday.Text);
                string level = cmblevel.Text;

                string query_update = "update Teacher set TeacherName='" + name + "',RegNo='" + regno + "',Email='" + email + "',Tp='" + tp + "',Gender='" + gender + "',WorkedDay='" + day + "',TeacherLevel='" + level + "' where RegNo='" + regno + "'";
                SqlCommand cmd2 = new SqlCommand(query_update, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Update successfully ....!!");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Updating" + ex);
            }tableLoard();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text;
                string regno = txtrn.Text;
                string email = txtemail.Text;
                int tp = int.Parse(txttp.Text);
                string gender;
                if (rbmale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                int day = int.Parse(txtday.Text);
                string level = cmblevel.Text;

                string query_delete = "delete from Teacher where RegNo='" + regno + "'";
                SqlCommand cmd3 = new SqlCommand(query_delete, con);
                con.Open();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully....!!");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Deleting " + ex);
            }tableLoard();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string u_reg = txtsearch.Text;
                string query_search = "select * from Teacher where RegNo='" + u_reg + "'";
                SqlCommand cmd4 = new SqlCommand(query_search, con);
                con.Open();
                SqlDataReader r = cmd4.ExecuteReader();
                while (r.Read())
                {
                    txtname.Text = r[1].ToString();
                    txtrn.Text = r[2].ToString();
                    txtemail.Text = r[3].ToString();
                    txttp.Text = r[4].ToString();
                    string gen = r[5].ToString();
                    if (gen == "Male")
                    {
                        rbmale.Checked = true;
                    }
                    else
                    {
                        rbfemale.Checked = true;
                    }
                    txtday.Text = r[6].ToString();
                    cmblevel.Text = r[7].ToString();
                   
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error while searching " + ex);
            }
            finally
            {
                con.Close();
            }//tableLoard();
        }

        private void cleanbtn_Click(object sender, EventArgs e)
        {
            txtname.Text = string.Empty;
            txtrn.Text = string.Empty;
            txtemail.Text = string.Empty;
            txttp.Text = string.Empty;
            txtsearch.Text = string.Empty;
            txtday.Text = string.Empty;
            cmblevel.Text = string.Empty;
            rbmale.Checked = false;
            rbfemale.Checked = false;
        }

        private void mainmenubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu obj = new MainMenu();
            obj.Show();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
