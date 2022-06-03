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
    public partial class SPofNVusercontrol : UserControl
    {
        public SPofNVusercontrol()
        {
            InitializeComponent();
            ShowSP();
            setcbb();
        }
        public void setcbb()
        {
            cbbSort.Items.Add("Ma San Pham");
            cbbSort.Items.Add("So luong san pham");
            cbbSort.Items.Add("Gia san pham");
        }
        public void ShowSP()
        {
            dataGridView1.DataSource = QLSHOPBLL.instance.GetSPView(QLSHOPBLL.instance.GetListSP());
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
