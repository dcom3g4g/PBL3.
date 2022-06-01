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

        }
        public void GUI()
        {
           // txt
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MA); 
            addHD a = new addHD(MA);
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
    }
}
