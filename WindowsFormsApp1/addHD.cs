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
    public partial class addHD : Form
    {
        public string MA = ""; 
        public addHD(string Ma)
        {
            InitializeComponent();
            MA = Ma;
            GUI(); 
        }
        public void GUI()
        {
            txtidnv.Text = MA;
            txtnamenv.Text = QLSHOPBLL.instance.GetNVByMaNV(MA).Name;
            txtday.Text = DateTime.Now.ToString();
            txtidhoadon.Text = QLSHOPBLL.instance.GetMaHDLast().ToString(); 
            foreach(SanPham i in QLSHOPBLL.instance.GetListSP() )
            {
                cbidsp.Items.Add(i.MSP); 
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbidsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtnamesp.Text = QLSHOPBLL.instance.GetSPbyMaSP(cbidsp.SelectedItem.ToString()).TenSP; 
        }
    }
}
