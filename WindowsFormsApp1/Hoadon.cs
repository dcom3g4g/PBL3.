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
        public Hoadon(string MA1,int x)
        {
            MA = MA1; 
            InitializeComponent();
            showHD();
            setcbb();
            if(x ==1)
            {
                button5.Visible = false;
            }    
        }

        public void setcbb()
        {
            cbbSort.Items.Add("Ma hoa don");
            cbbSort.Items.Add("Tong so luong");
            cbbSort.Items.Add("Tong tien");
            cbbnam.Items.Add("All");
            cbbngay.Enabled = false;
            cbbthang.Enabled = false; 
            foreach (string i in QLSHOPBLL.instance.GetNam())
                cbbnam.Items.Add(i);
            //cbbnam.SelectedIndex = 0;
            cbbthang.Items.Add("All");
            
            for (int i=1;i<13;i++)
            {
                cbbthang.Items.Add(i.ToString()); 
            }
            //cbbthang.SelectedIndex = 0;
            cbbngay.Items.Add("All");
            
            for (int i = 1; i < 32; i++)
            {
                cbbngay.Items.Add(i.ToString());
            }
             //  cbbngay.SelectedIndex = 0;

        }
        public void GUI()
        {
           // txt
        }
        public void showHD()
        {
            //dataGridView1.DataSource = QLSHOPBLL.instance.GetChiTietHoaDonViews(QLSHOPBLL.instance.GetListChiTietHoaDon());
            dataGridView1.DataSource = QLSHOPBLL.instance.GetHoaDonView(QLSHOPBLL.instance.GetListHD());

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MA); 
            addHD a = new addHD(MA,"",0);
            a.d = new addHD.Mydel(showHD);
            a.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (cbbSort.SelectedItem == null)
                MessageBox.Show("Chua chon thuoc tinh sap xep");
            else dataGridView1.DataSource = QLSHOPBLL.instance.GetHoaDonView(QLSHOPBLL.instance.SortHD(cbbSort.SelectedItem.ToString()));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =QLSHOPBLL.instance.GetHoaDonView(QLSHOPBLL.instance.SearchHD(txtSearch.Text));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                addHD f = new addHD(dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["MaHD"].Value.ToString(), 1);
                f.d = new addHD.Mydel(showHD);
                f.Show();
            }
        }

     

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbthang.SelectedIndex = 0;
            cbbngay.Enabled = true;
            cbbthang.Enabled = true;
            cbbngay.SelectedIndex = 0;
            dataGridView1.DataSource = QLSHOPBLL.instance.GetHoaDonView(QLSHOPBLL.instance.GetListHoaDon(cbbngay.SelectedItem.ToString(), cbbthang.SelectedItem.ToString(), cbbnam.SelectedItem.ToString())); 
        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbngay.SelectedIndex = 0;
            dataGridView1.DataSource = QLSHOPBLL.instance.GetHoaDonView(QLSHOPBLL.instance.GetListHoaDon(cbbngay.SelectedItem.ToString(), cbbthang.SelectedItem.ToString(), cbbnam.SelectedItem.ToString()));
        }

        private void cbbngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbbngay.SelectedIndex = 0;
            dataGridView1.DataSource = QLSHOPBLL.instance.GetHoaDonView(QLSHOPBLL.instance.GetListHoaDon(cbbngay.SelectedItem.ToString(), cbbthang.SelectedItem.ToString(), cbbnam.SelectedItem.ToString()));
        }
    }
}
