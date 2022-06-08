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
        public List<ChiTietHoaDonView> list = new List<ChiTietHoaDonView>() ;
        
        public delegate void Mydel();
        public Mydel d { get; set; }
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
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbidsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtnamesp.Text = QLSHOPBLL.instance.GetSPbyMaSP(cbidsp.SelectedItem.ToString()).TenSP;
            updownsl.Maximum = (QLSHOPBLL.instance.GetSLSPByMSPandSize(cbidsp.SelectedItem.ToString(), Convert.ToInt32(updownsize.Value)));
            updownsl.Minimum = 0;
        }

        private void updownsize_ValueChanged(object sender, EventArgs e)
        {
            updownsl.Maximum=(QLSHOPBLL.instance.GetSLSPByMSPandSize(cbidsp.SelectedItem.ToString(), Convert.ToInt32( updownsize.Value)));
            updownsl.Minimum = 0; 
            //MessageBox.Show(MA + updownsize.Value.ToString()); 
        }
        public void Show(List<ChiTietHoaDonView>  a)
        {
            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = a;
            txttongtien.Text = Total().ToString();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public int Total ()
        {
            int tong = 0;
            foreach (ChiTietHoaDonView i in list)
            {
                tong = tong + i.TongTien;
                //dem = dem + i.SoLuong; 
            }
            return tong; 
        }
        public int TotalSLSP()
        {
            int dem = 0;
            foreach (ChiTietHoaDonView i in list)
            {
                dem = dem + i.SoLuong;
            }
            return dem;
        }
        public void Check(string MASP, int size)
        {
            try
            {
                foreach (ChiTietHoaDonView i in list)
                {
                    if (i.MaSP == MASP && i.Size == size)
                        list.Remove(i);
                }
            }
            catch (Exception e)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Check(cbidsp.SelectedItem.ToString(), Convert.ToInt32(updownsize.Value)); 
            list.Add(new ChiTietHoaDonView{ MaSP=cbidsp.SelectedItem.ToString(),Size=Convert.ToInt32(updownsize.Value), SoLuong=Convert.ToInt32(updownsl.Value),GiaThanh= QLSHOPBLL.instance.GetGiaThanhByMaSP(cbidsp.SelectedItem.ToString()) , TongTien= QLSHOPBLL.instance.GetGiaThanhByMaSP(cbidsp.SelectedItem.ToString()) * Convert.ToInt32(updownsl.Value) }) ;
            //MessageBox.Show(list.Count.ToString()); 
            //MessageBox.Show(cbidsp.SelectedItem.ToString() + Convert.ToInt32(updownsl.Value).ToString());
            Show(list); 
           // Show(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    list.RemoveAt(i.Index); 
            }
            Show(list); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLSHOPBLL.instance.AddHoaDon(new HoaDon { MaHD=txtidhoadon.Text, MaNV = MA, TongSL = TotalSLSP(), TongTien = Total() ,NgayThang=DateTime.Now});
            foreach (ChiTietHoaDonView i in list)
            {
                QLSHOPBLL.instance.AddChitiethoadon(new ChiTietHoaDon { MaHD = txtidhoadon.Text, MSP = i.MaSP, Size = i.Size, SoLuong = i.SoLuong });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = i.MaSP, Size = i.Size, SoLuong = QLSHOPBLL.instance.GetSLSPByMSPandSize(i.MaSP,i.Size)- i.SoLuong }); ;
                QLSHOPBLL.instance.UpdateTongSLSPbyMaSP(i.MaSP, i.SoLuong); 
            }
            QLSHOPBLL.instance.AddDoanhThu(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, new DoanhThu { NgayThang = DateTime.Now, Tongtien = Total() }); 
            d();
            this.Close();
        }
    }
}
