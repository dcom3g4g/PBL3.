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
        public bool isowner(Account a)
        {
            //var l1=db.Accounts.
            return true;
        }
        public List<Account> GetListacc()
            {
            return db.Accounts.ToList();
            }

    }
}
