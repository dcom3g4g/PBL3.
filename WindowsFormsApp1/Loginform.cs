using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class Loginform : Form
    {
        QLSHOP db = new QLSHOP();
        public Loginform()
        {
            InitializeComponent();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            forgetpasswordform a = new forgetpasswordform();
            a.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (QLSHOPBLL.instance.getaccount(txtTK.Text, txtMK.Text) == 1)
            {
                this.Hide();
                EmployeeForm a = new EmployeeForm();
                a.Show();
            }
            else if (QLSHOPBLL.instance.getaccount(txtTK.Text, txtMK.Text) == 2)
            {
                this.Hide();
                OwnerForm a = new OwnerForm();
                a.Show();
            }
            else
            {
                MessageBox.Show("Tai khoan khong ton tai");
            }
        }
    }
}
