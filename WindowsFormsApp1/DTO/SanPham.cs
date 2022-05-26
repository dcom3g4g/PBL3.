using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class SanPham
    {
        [Key]
        public string MSP { get; set; }
        public int TongSLSP { get; set; }
        public string Link { get; set; }
        public string TenSP { get; set; }   
        public string GiaSP { get; set; }
        public string LoaiSP { get; set; }
        public int HoaHong { get; set;  }
    }
}
