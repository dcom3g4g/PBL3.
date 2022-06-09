using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.BLL
{
    internal class QLSHOPBLL
    {
        QLSHOP db = new QLSHOP();
        private static QLSHOPBLL _instance;
        public static QLSHOPBLL instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QLSHOPBLL();
                return _instance;
            }
            private set { }
        }
       

        public bool Check(string MS)
        {
            if (db.SanPhams.Where(p => p.MSP == MS).FirstOrDefault() != null)
                return true; 
            return false;
        }
        public bool CheckSL(string MS,int si)
        {
            if (db.SoLuongSPs.Where(p=>p.MSP==MS && p.Size==si).FirstOrDefault()!=null)
                return true;
            return false; 
        }
        public void AddUpdateSP(SanPham s)
        {
            if (Check(s.MSP) == false)
            {
                db.SanPhams.Add(s);
            }
            else
            {
                var l1 = db.SanPhams.Where(p=>p.MSP == s.MSP).FirstOrDefault();
                l1.MSP = s.MSP;
                l1.Link=s.Link;
                l1.TongSLSP=s.TongSLSP;
                l1.GiaSP = s.GiaSP;
                l1.TenSP = s.TenSP;
            }
            db.SaveChanges();
        }
        public void UpdateTongSLSPbyMaSP(string Ma,int SLtru)
        {
            var l1 = db.SanPhams.Where(p => p.MSP == Ma).FirstOrDefault();
            l1.TongSLSP = l1.TongSLSP - SLtru;
            db.SaveChanges(); 
        }
        public int GetSLSPByMSPandSize(string MSP, int size)
        {

            if (db.SoLuongSPs.Where(p => p.MSP == MSP && p.Size == size).FirstOrDefault() == null)
                return 0; 
            else  return db.SoLuongSPs.Where(p => p.MSP == MSP && p.Size == size).ToList().FirstOrDefault().SoLuong;
            return 0; 
          
        }
        public void AddHoaDon(HoaDon s)
        {
            db.Hoadons.Add(s);
            db.SaveChanges(); 
        }
        public void AddDoanhThu(int ngay, int thang, int nam, DoanhThu s)
        {
            if (db.DoanhThuNams.Where(p=>p.NgayThang.Day==ngay && p.NgayThang.Month==thang && p.NgayThang.Year==nam).FirstOrDefault()==null)
            {
                db.DoanhThuNams.Add(s);
                db.SaveChanges(); 
            }
            else 
            {
                var l1 = db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList().FirstOrDefault();
                l1.Tongtien = l1.Tongtien + s.Tongtien;
                db.SaveChanges(); 
            }
        }
        public void AddChitiethoadon(ChiTietHoaDon s)
        {
            db.ChiTietHoaDons.Add(s);
            db.SaveChanges(); 
        }
        public List<HoaDon> GetListHD()
        {
            return db.Hoadons.Select(p => p).ToList(); 
        }
        public void AddSLSP(SoLuongSP s)
        {
            if (CheckSL(s.MSP,s.Size) == false)
            {
                db.SoLuongSPs.Add(s);
            }
            else
            {
                var l1 = db.SoLuongSPs.Where(p => p.MSP == s.MSP && p.Size == s.Size).FirstOrDefault();
                l1.SoLuong = s.SoLuong;
                
            }
            db.SaveChanges();
        }
        public int GetSLbyMaSPandSize(string MS,int sz)
        {
            return db.SoLuongSPs.Where(p => p.MSP == MS && p.Size == sz).ToList().FirstOrDefault().SoLuong; 
        }
        public SanPham GetSPbyMaSP(string MS)
        {
            return db.SanPhams.Where(p => p.MSP == MS).ToList().FirstOrDefault(); 
        }
        public List<SanPham> GetListSP()
        {
            return db.SanPhams.ToList();
        }
        public List<Account> GetListacc()
            {
            return db.Accounts.ToList();
            }
        public int getaccount(string TK, string MK)
        {
             if (db.Accounts.Where(p => p.TenDangNhap == TK && p.MatKhau == MK).Select(p => p).ToList().FirstOrDefault()==null)
                return 0;

            else if (db.Accounts.Where(p => p.TenDangNhap == TK && p.MatKhau == MK).Select(p => p).ToList().FirstOrDefault().IsOwner)
            return 2;
             
            return 1; 
        }

        public string forgotpassword(string account, string gmail)
        {

            if (db.Nhanviens.Where(p => p.MaNV == account && p.Gmail == gmail).Select(p => p).ToList().FirstOrDefault() == null)
                return "0";
            else

            {
                return db.Accounts.Where(p => p.TenDangNhap == account).Select(p => p.MatKhau).ToList().FirstOrDefault();

            }
            
        }

        public int FindPassword(string account, string password,string newpassword,string conformpassword)
        {
            if(db.Accounts.Where(p=> p.TenDangNhap == account && p.MatKhau == password).Select(p => p).ToList().FirstOrDefault() != null)
            {
                if (newpassword == conformpassword)
                {
                    return 0;
                }
                else
                    return 1;
            }
            return 2;
        }

        public void changepassword(string account,string newpassword)
        {

            var l1 = db.Accounts.Where(p => p.TenDangNhap == account).FirstOrDefault();
            l1.MatKhau = newpassword;
            db.SaveChanges();
        }

        public List<NhanVien> GetListNhanVien() 
        {
            return db.Nhanviens.ToList();
        }

        public bool checkNV(string MNV)
        {
            if (db.Nhanviens.Where(p => p.MaNV == MNV).ToList().FirstOrDefault() != null)
                return true;
            return false;
        }
        public int  GetGiaThanhByMaSP(string MA)
        {
            return Convert.ToInt32(db.SanPhams.Where(p => p.MSP == MA).ToList().FirstOrDefault().GiaSP); 
        }
        public List<NhanVienView> GetNhanvienViews(List<NhanVien> a)
        {
            List<NhanVienView> nv = new List<NhanVienView>();
            foreach (NhanVien v in a)
            {
                nv.Add(new NhanVienView
                {
                    MaNV = v.MaNV,
                    Name = v.Name,
                    Gmail = v.Gmail,
                    SDT = v.SDT,
                    LuongCB = v.LuongCB,
                    Gender = v.Gender,
                    DiaChi = v.DiaChi,
                    NgaySinh = v.NgaySinh,
                    SoGioLamViec = v.SoGioLamViec,
                });
            }
            return nv;
        }
      
        public void AddUpdateNV(NhanVien n)
        {
            if(checkNV(n.MaNV) == false)
            {
                db.Nhanviens.Add(n);
                db.Accounts.Add(new Account { TenDangNhap = n.MaNV, MatKhau = "123", IsOwner = false });
               
            }
            else
            {
                var l1 = db.Nhanviens.Where(p => p.MaNV == n.MaNV).FirstOrDefault();
                l1.MaNV = n.MaNV;
                l1.Name = n.Name;
                l1.Gmail = n.Gmail;
                l1.SDT = n.SDT;
                l1.LuongCB = n.LuongCB;
                l1.Gender = n.Gender;
                l1.DiaChi = n.DiaChi;
                l1.NgaySinh = n.NgaySinh;
            }

            db.SaveChanges();
        }

        public void DelNV(string MNV)
        {
            db.Nhanviens.Remove(db.Nhanviens.Find(MNV));
            db.Accounts.Remove(db.Accounts.Find(db.Accounts.Where(p => p.TenDangNhap == MNV).ToList().FirstOrDefault().ID));
            db.SaveChanges();
        }
        public void DelHD(string MHD)
        {
            db.Hoadons.Remove(db.Hoadons.Find(MHD));
            db.SaveChanges(); 
        }


        public NhanVien GetNVByMaNV(string MNV)
        {
            return db.Nhanviens.Where(p => p.MaNV == MNV).ToList().FirstOrDefault();
        }
        public int GetDoanhThuTrongNgay(int ngay , int thang , int nam)
        {
            if (db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).FirstOrDefault() == null)
                return 0;
            else return db.DoanhThuNams.Where(p => p.NgayThang.Day == ngay && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList().FirstOrDefault().Tongtien;
            return 0; 
        }
        public double GetDoanhThuThang(int tuan,int thang, int nam)
        {
            double x = 0; 
            if (tuan==1)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 7 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien; 
                }
            }
            if (tuan == 2)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 14 && p.NgayThang.Day>7 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            if (tuan == 3)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 21 && p.NgayThang.Day > 14 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            if (tuan == 4)
            {
                foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Day <= 28 && p.NgayThang.Day > 21 && p.NgayThang.Month == thang && p.NgayThang.Year == nam).ToList())
                {
                    x += i.Tongtien;
                }
            }
            return x;
        }
        public double GetDoanhThuNam( int quy, int nam)
        {
            double x = 0;
            if (quy==1)
            foreach (DoanhThu i in db.DoanhThuNams.Where( p=>p.NgayThang.Month >=1 && p.NgayThang.Month < 4 && p.NgayThang.Year == nam).ToList())
            {
                x += i.Tongtien;
            }
            if (quy == 2)
            foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 4 && p.NgayThang.Month < 7 && p.NgayThang.Year == nam).ToList())
            {
                x += i.Tongtien;
            }
            if (quy == 3)
            foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 7 && p.NgayThang.Month < 10 && p.NgayThang.Year == nam).ToList())
            {
                x += i.Tongtien;
            }
            if (quy == 4)
            foreach (DoanhThu i in db.DoanhThuNams.Where(p => p.NgayThang.Month >= 10 && p.NgayThang.Month < 13 && p.NgayThang.Year == nam).ToList())
            {
                x += i.Tongtien;
            }

            return x;
        }

        public int GetMaHDLast()
        {
            if (db.Hoadons.OrderBy(p => p.MaHD).FirstOrDefault() == null)
                return 1;
            else return  (Convert.ToInt32( db.Hoadons.OrderByDescending(p => p.MaHD).ToList().FirstOrDefault().MaHD) + 1);
            return 1; 
        }
        public List<NhanVien> SortNV(string type)
        {
            List<NhanVien> data = QLSHOPBLL.instance.GetListNhanVien();
            switch(type)
            {
                case "Ma Nhan Vien":
                    {
                        data = db.Nhanviens.OrderBy(p => p.MaNV).ToList();
                        break;
                    }
                case "Ten Nhan Vien":
                    {
                        data = db.Nhanviens.OrderBy(p => p.Name).ToList();
                        break;
                    }
                case "Luong co ban":
                    {
                        data = db.Nhanviens.OrderBy(p => p.LuongCB).ToList();
                        break;
                    }
            }
            return data;
        }
        public List<NhanVien> SeachNV(string s)
        {
            List<NhanVien> data = new List<NhanVien>();
            data = db.Nhanviens.Where(p=> p.MaNV.Contains(s) || p.Name.Contains(s)).ToList();
            return data;
        }
        public void DellSP(string MS)
        {
            db.SanPhams.Remove(db.SanPhams.Find(MS)) ;
            db.SaveChanges(); 
        }
        
        public List<SanPhamView> GetSPView(List<SanPham> a)
        {
            List<SanPhamView> data = new List<SanPhamView>();
            foreach(SanPham i in a)
            {
                data.Add(new SanPhamView
                {
                    MSP = i.MSP,
                    TongSLSP = i.TongSLSP,
                    TenSP = i.TenSP,
                    GiaSP = i.GiaSP
                });
            }
            return data;
        }

        public List<SanPham> SortSP(string type)
        {
            
            List<SanPham> data = QLSHOPBLL.instance.GetListSP();
            switch(type)
            {
                case "Ma San Pham":
                    {
                        data = db.SanPhams.OrderBy(p => p.MSP).ToList();
                        break;
                    }
                case "So luong san pham":
                    {
                        data = db.SanPhams.OrderBy(p => p.TongSLSP).ToList();
                        break;
                    }
                case "Gia san pham":
                    {
                        data = db.SanPhams.OrderBy(p => p.GiaSP).ToList();
                        break;
                    }
            }
            return data;
            
        }

        public List<SanPham> SearchSP(string s)
        {
            List<SanPham> data = new List<SanPham>();
            data = db.SanPhams.Where(p => p.MSP.Contains(s) || p.TenSP.Contains(s)).Select(p => p).ToList();
            return data;
        }

        public List<HoaDon> SortHD(string type)
        {
            List<HoaDon> data = QLSHOPBLL.instance.GetListHD();
            switch (type)
            {
                case "Ma hoa don":
                    {
                        data = db.Hoadons.OrderBy(p => p.MaHD).ToList();
                        break;
                    }
                case "Tong so luong":
                    {
                        data = db.Hoadons.OrderBy(p => p.TongSL).ToList();
                        break;
                    }
                case "Tong tien":
                    {
                        data = db.Hoadons.OrderBy(p => p.TongTien).ToList();
                        break;
                    }
            }
            return data;
        }

        public List<HoaDon> SearchHD(string s)
        {
            List<HoaDon> data = new List<HoaDon>();
            data = db.Hoadons.Where(p => p.MaHD.Contains(s) || p.MaNV.Contains(s)).Select(p=>p).ToList();
            return data;
        }

        public List<Hoadonview> GetHoaDonView(List<HoaDon> a)
        {
            List<Hoadonview> data = new List<Hoadonview>();
            foreach (HoaDon i in a)
            {
                data.Add(new Hoadonview
                {
                    MaHD = i.MaHD,
                    NgayThang = i.NgayThang,
                    TongSL = i.TongSL,
                    TongTien = i.TongTien,
                    MaNV = i.MaNV,
                });
            }
            return data;
        }

        public void AddGio(string MaNV, double time)
        {
            var l1 = db.Nhanviens.Where(p => p.MaNV == MaNV).FirstOrDefault();
            l1.SoGioLamViec += time;
            db.SaveChanges();
        }
    }
}
