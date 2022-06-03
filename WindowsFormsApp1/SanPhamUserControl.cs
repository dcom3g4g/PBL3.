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
    public partial class SanPhamUserControl : UserControl
    {
        public SanPhamUserControl()
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
        private void butadd_Click(object sender, EventArgs e)
        {
            ChiTietSP f = new ChiTietSP("");
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChiTietSP f = new ChiTietSP("");
            f.d = new ChiTietSP.Mydel(ShowSP);
            f.Show(); 
            //ShowSP();
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ChiTietSP f = new ChiTietSP(dataGridView1.SelectedRows[0].Cells["MSP"].Value.ToString());
                f.d = new ChiTietSP.Mydel(ShowSP);
                f.Show();
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLSHOPBLL.instance.DellSP(i.Cells["MSP"].Value.ToString());
                }
            };
            ShowSP(); 
        }

        private void btsort_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSHOPBLL.instance.GetSPView(QLSHOPBLL.instance.SortSP(cbbSort.SelectedItem.ToString()));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSHOPBLL.instance.GetSPView(QLSHOPBLL.instance.SearchSP(txtSearch.Text));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
