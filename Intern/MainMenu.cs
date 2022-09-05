using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Intern
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student obj1 = new Student();
            obj1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers obj2 = new Teachers();
            obj2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Calculations obj3 = new Calculations();
            obj3.Show();
        }
    }
}
