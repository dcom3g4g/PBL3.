﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class forgetpasswordform : Form
    {
        public forgetpasswordform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            



            this.Close();
            Loginform a = new Loginform();
            a.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginform a= new Loginform();
            a.Show();
        }
    }
}
