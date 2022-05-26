using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class DoanhThuTuan
    {
        [Key]
        public int ID { get; set; }
        public int Ngay1 { get; set; }
        public int Ngay2 { get; set; }
        public int Ngay3 { get; set; }
        public int Ngay4 { get; set; }
        public int Ngay5 { get; set; }
        public int Ngay6 { get; set; }
        public int Ngay7 { get; set; }

    }
}
