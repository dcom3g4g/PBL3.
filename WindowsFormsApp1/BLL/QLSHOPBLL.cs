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

        //public int forgotpassword(string Account, string gmail)
        //{
        //    if()
        //}

    }
}
