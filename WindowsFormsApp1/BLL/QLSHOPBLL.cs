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

        public void AddUpdateNV(NhanVien n)
        {
            if(checkNV(n.MaNV))
            {
                db.Nhanviens.Add(n);
                db.Accounts.AddRange(new Account[]
                {
                    new Account{TenDangNhap = n.MaNV, MatKhau="123",IsOwner = false},
                });
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


        public NhanVien GetNVByMaNV(string MNV)
        {
            return db.Nhanviens.Where(p => p.MaNV == MNV).ToList().FirstOrDefault();
        }

        public int GetMaHDLast()
        {
            if (db.Hoadons.OrderBy(p => p.MaHD).FirstOrDefault() == null)
                return 1;
            else return  (Convert.ToInt32( db.Hoadons.OrderBy(p => p.MaHD).ToList().FirstOrDefault().MaHD) + 1);
            return 1; 
        }
        public void DellSP(string MS)
        {
            db.SanPhams.Remove(db.SanPhams.Find(MS)) ;
            db.SaveChanges(); 
        }
        //public int forgotpassword(string Account, string gmail)
        //{
        //    if()
        //}

    }
}
