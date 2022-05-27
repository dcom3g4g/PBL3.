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

        
        public void showNV()
        {
            dataGridView1.DataSource = QLSHOPBLL.instance.GetListNhanVien();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            AddNV f = new AddNV("");
            f.d = new AddNV.Mydel(showNV);
            f.Show();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                AddNV f = new AddNV(dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString());
                f.d = new AddNV.Mydel(showNV);
                f.Show();
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLSHOPBLL.instance.DelNV(i.Cells["MaNV"].Value.ToString());
                }
            }
            showNV();
        }

       
    }
}
