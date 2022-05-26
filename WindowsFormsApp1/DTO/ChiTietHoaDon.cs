using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        public string MaHD { get; set; }
        public string TenSP { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public int Size { get; set; }
        public int GiaSP { get; set; }
    }
}
