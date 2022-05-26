using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class DoanhThuThang
    {
        [Key]
        public int ID { get; set; }
        public int Tuan1 { get; set; }
        public int Tuan2 { get; set; }
        public int Tuan3 { get; set; }
        public int Tuan4 { get; set; }
    }
}
