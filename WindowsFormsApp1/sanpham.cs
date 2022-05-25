using System;
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
    public partial class sanpham : UserControl
    {
        public sanpham()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void butadd_Click(object sender, EventArgs e)
        {
            Detailsanpham  f = new Detailsanpham();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Detailsanpham f = new Detailsanpham();
            f.Show();
        }
    }
}
