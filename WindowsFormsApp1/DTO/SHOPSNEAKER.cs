using System;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1
{
    public class SHOPSNEAKER : DbContext
    {
        
        public SHOPSNEAKER()
            : base("name=SHOPSNEAKER")
        {
        }   
    }
}