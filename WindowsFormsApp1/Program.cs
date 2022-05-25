using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new EmployeeForm());
            Console.WriteLine(" x");
            Console.WriteLine(" Z");
=======

            Console.WriteLine(" x"); 

            Application.Run(new Loginform());

>>>>>>> 806b723bb950793613414bff102ba33114f5f770
        }
    }
}
