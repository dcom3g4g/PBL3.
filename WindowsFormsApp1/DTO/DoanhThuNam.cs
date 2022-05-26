using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class DoanhThuNam
    {
        [Key]
        public int ID { get; set; }
        public int Quy1 { get; set;  }
        public int Quy2 { get; set; }
        public int Quy3 { get; set; }
        public int Quy4 { get; set; }
    }
}
