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

namespace WindowsFormsApp1
{
    public partial class Nhanvienusercontrol : UserControl
    {
        public Nhanvienusercontrol()
        {
            InitializeComponent();
            dataGridView1.DataSource = QLSHOPBLL.instance.GetListNhanVien();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void showNV()
        {
            dataGridView1.DataSource = QLSHOPBLL.instance.GetListNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddNV a = new AddNV();
            a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLSHOPBLL.instance.DelNV(i.Cells["MaNV"].Value.ToString());
                }
            }
            showNV();
        }
    }
}
