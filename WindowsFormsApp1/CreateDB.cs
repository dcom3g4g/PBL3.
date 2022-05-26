using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    internal class CreateDB : CreateDatabaseIfNotExists<QLSHOP>
    {
        
        protected override void Seed(QLSHOP context)
        {
            Console.WriteLine("cO TAO 222");
            context.Accounts.AddRange(new Account[]
            {
                new Account{ID=1,TenDangNhap="NV01",MatKhau="123",IsOwner=false},
                new Account{ID=2,TenDangNhap="NV02",MatKhau="123",IsOwner=false},
                new Account{ID=3,TenDangNhap="Admin",MatKhau="123",IsOwner=true},
            });
            Console.WriteLine("cO TAO");

        }
    }
}
