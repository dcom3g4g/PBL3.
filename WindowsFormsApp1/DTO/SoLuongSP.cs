using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class SoLuongSP
    {
        [Key]
        public int ID { get; set; }
        public string MSP { get; set; }
        public int SoLuong { get; set; }
        public int Size { get; set; }
    }
}
