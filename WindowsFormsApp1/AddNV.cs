using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class AddNV : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string MNV;
        public AddNV(string MaNV)
        {
            InitializeComponent();
            MNV = MaNV;
            GUI();
        }

        public void GUI()
        {
            NhanVien s = QLSHOPBLL.instance.GetNVByMaNV(MNV);
            if(MNV != "")
            {
                txtID.Enabled = false;
                txtID.Text = s.MaNV;
                txtName.Text = s.Name;
                Txtngaysinh.Text = s.NgaySinh;
                txtSDT.Text = s.SDT.ToString();
                txtLuong.Text = s.LuongCB.ToString();
                txtGmail.Text = s.Gmail;
                txtaddress.Text = s.DiaChi;
                if (s.Gender)
                    rdMale.Checked = true;
                else
                    rdFemale.Checked = true;

            }
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            Txtngaysinh.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
            txtGmail.Text = "";
            txtaddress.Text = "";
            rdMale.Checked = false;
            rdFemale.Checked = false;
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            QLSHOPBLL.instance.AddUpdateNV(new NhanVien
            {
                MaNV = txtID.Text,
                Name = txtName.Text,
                Gmail = txtGmail.Text,
                SDT = Convert.ToInt32(txtSDT.Text),
                LuongCB = Convert.ToInt32(txtLuong.Text),
                Gender = rdMale.Checked,
                DiaChi = txtaddress.Text,
                NgaySinh = Txtngaysinh.Text,
            }) ;
            d();
            this.Close();
        }
    }
}
