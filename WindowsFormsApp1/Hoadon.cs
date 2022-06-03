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
    public partial class Hoadon : UserControl
    {
        // QLSHOPBLL QL = new QLSHOPBLL(); 
        public string MA = ""; 
        public Hoadon(string MA1)
        {
            MA = MA1; 
            InitializeComponent();
            showHD(); 

        }
        public void GUI()
        {
           // txt
        }
        public void showHD()
        {
            dataGridView1.DataSource = (QLSHOPBLL.instance.GetListHD());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MA); 
            addHD a = new addHD(MA);
            a.d = new addHD.Mydel(showHD);
            a.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSHOPBLL.instance.GetListacc(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLSHOPBLL.instance.DelHD(i.Cells["MaHD"].Value.ToString());
                }
            }
            showHD(); 
        }
    }
}
