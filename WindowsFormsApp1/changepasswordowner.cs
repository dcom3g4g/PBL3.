﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class changepasswordowner : Form
    {
        public changepasswordowner()
        {
            InitializeComponent();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QLSHOPBLL.instance.FindPassword(txtaccount.Text, txtpassword.Text, txtnewpassword.Text, txtconform.Text) == 0)
            {
                QLSHOPBLL.instance.changepassword(txtaccount.Text, txtnewpassword.Text);
                this.Close();
            }
            else if (QLSHOPBLL.instance.FindPassword(txtaccount.Text, txtpassword.Text, txtnewpassword.Text, txtconform.Text) == 1)
                MessageBox.Show("Mat khau moi khong trung khop");
            else
                MessageBox.Show("Ten tai khoan hoac mat khau khong dung");
            
        }
    }
}
