using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class HoaDon
    {
        [Key]
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public int TongSL { get; set; }
        public int TongTien { get; set; }

    }
}
