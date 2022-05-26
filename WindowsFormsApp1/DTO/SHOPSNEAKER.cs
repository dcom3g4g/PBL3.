using System;
using System.Data.Entity;
using System.Linq;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public class SHOPSNEAKER : DbContext
    {
        
        public SHOPSNEAKER()
            : base("name=SHOPSNEAKER")
        {
            //Database.SetInitializer<SHOPSNEAKER>(new CreateDB());
            Console.WriteLine("co tao 111");
        }
        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<DoanhThuTuan> DoanhThuTuans { get; set; }

        public virtual DbSet<DoanhThuThang> DoanhThuThangs { get; set; }
        public virtual DbSet<DoanhThuNam> DoanhThuNams { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<SoLuongSP> SoLuongSPs { get; set; }
    }
}