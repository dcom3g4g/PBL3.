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
    public partial class DoanhThuThang : UserControl
    {
        public DoanhThuThang()
        {
            InitializeComponent();
            loaddl(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loaddl()
        {
            chartthang.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Tuần 1", 15);
            chartthang.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Tuần 2", 20);
            chartthang.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Tuần 3", 40);
            chartthang.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Tuần 4", 19);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuTuan"].BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuNam"].BringToFront();
        }
    }
}
