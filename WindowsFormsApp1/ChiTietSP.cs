using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.BLL; 
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ChiTietSP : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string MSP;  
        public ChiTietSP(string MaSP, int x)
        {
            InitializeComponent();
            MSP = MaSP;
            GUI();        
            if(x ==1)
            {
                button1.Visible = false;
                Txtpic.Enabled = false;
                txtID.Enabled = false;
                txtName.Enabled = false;
                txtPrice.Enabled = false;
                txtSize36.Enabled = false;
                txtSize37.Enabled = false;
                txtSize38.Enabled = false;
                txtSize39.Enabled = false;
                txtSize40.Enabled = false;
                txtSize41.Enabled = false;
                txtSize42.Enabled = false;
                txtSize43.Enabled = false;


            }    
        }
        public void GUI()
        {
            SanPham s= QLSHOPBLL.instance.GetSPbyMaSP(MSP);
            
            if (MSP!="")
            {
                pictureBox1.Image = new Bitmap(s.Link);
                txtID.Text = MSP;
                Txtpic.Text = s.Link;
                txtName.Text = s.TenSP;
                txtPrice.Text = s.GiaSP;
                txtSize36.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 36).ToString();
                txtSize37.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 37).ToString();
                txtSize38.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 38).ToString();
                txtSize39.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 39).ToString();
                txtSize40.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 40).ToString();
                txtSize41.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 41).ToString();
                txtSize42.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 42).ToString();
                txtSize43.Text = QLSHOPBLL.instance.GetSLbyMaSPandSize(s.MSP, 43).ToString();
            }
        }
        private void ChiTietSP_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
     
                QLSHOPBLL.instance.AddUpdateSP(new SanPham
                {
                    MSP = txtID.Text,
                    Link = Txtpic.Text,
                    GiaSP = txtPrice.Text,
                    TenSP = txtName.Text,
                    TongSLSP = Convert.ToInt32(txtSize36.Text) + Convert.ToInt32(txtSize37.Text) + Convert.ToInt32(txtSize38.Text) + Convert.ToInt32(txtSize39.Text) + Convert.ToInt32(txtSize40.Text) + Convert.ToInt32(txtSize41.Text) + Convert.ToInt32(txtSize42.Text) + Convert.ToInt32(txtSize43.Text)
                });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 36, SoLuong = Convert.ToInt32(txtSize36.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 37, SoLuong = Convert.ToInt32(txtSize37.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 38, SoLuong = Convert.ToInt32(txtSize38.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 39, SoLuong = Convert.ToInt32(txtSize39.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 40, SoLuong = Convert.ToInt32(txtSize40.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 41, SoLuong = Convert.ToInt32(txtSize41.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 42, SoLuong = Convert.ToInt32(txtSize42.Text) });
                QLSHOPBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 43, SoLuong = Convert.ToInt32(txtSize42.Text) });
                d();
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(file.FileName);
                Txtpic.Text = file.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
