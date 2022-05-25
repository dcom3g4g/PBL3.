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
    public partial class DoanhThuTuan : UserControl
    {
        public DoanhThuTuan()
        {
            InitializeComponent();
            Loaddl(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuThang"].BringToFront();
        }

        private void Loaddl()
        {
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Thứ 2", 1);
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Thứ 3", 1.2);
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Thứ 4", 1.6);
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Thứ 5", 4);
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Thứ 6", 2);
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Thứ 7", 1.6);
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Chủ Nhật", 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuNam"].BringToFront();
        }
    }
}
