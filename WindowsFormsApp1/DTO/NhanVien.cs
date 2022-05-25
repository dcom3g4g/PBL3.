using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    internal class NhanVien
    {
        [Key]
        public string ID { get; set;  }
        public string Name { get; set; }
        public string Gmail { get; set; }
        public int SDT { get; set; }
        public bool Gender { get; set; }
        public string DiaChi { get; set;  }
        public string NgaySinh { get;  set; }
    }
}
