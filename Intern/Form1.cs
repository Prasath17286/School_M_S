using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtmail.Text;
            string pass = txtpassword.Text;

            if(email=="tharaka@gmail.com"&& pass == "1234")
            {
                MessageBox.Show("Login success ....!!!");
                this.Hide();
                MainMenu obj = new MainMenu();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Login not success.....!!!");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
