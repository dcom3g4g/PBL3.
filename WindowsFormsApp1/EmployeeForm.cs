using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EmployeeForm : Form
    {
        public static string Ma = "";
        static EmployeeForm _obj;

        // public sanpham sp = new sanpham();
        public Hoadon hd;
        
        //public sanpham sp = new sanpham();
 
        public Employee_user Employeeuser;
        //public Employee_user Employeeuser = new Employee_user();
     
        public SPofNVusercontrol sp = new SPofNVusercontrol();
      
        //public Hoadon hd = new Hoadon();
       // public Employee_user Employeeuser = new Employee_user();
        public SanPhamUserControl sanpham = new SanPhamUserControl();
        //public Hoadon hd = new Hoadon();

        public static EmployeeForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new EmployeeForm(null);
                }
                return _obj;
            }
        }
        public Panel panel4_
        {
            get { return panel4; }
            set { panel4 = value; }
        }
        
        public EmployeeForm(string MANV)
        { 
            Ma = MANV;
            Employee_user Employeeuser = new Employee_user(Ma);
            Hoadon hd = new Hoadon(Ma);
            
            InitializeComponent();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = this;
            Employee_user Employeeuser = new Employee_user(Ma);
            Hoadon hd = new Hoadon(Ma);
            sanpham.Dock = DockStyle.Fill;
            panel4.Controls.Add(sanpham);
            hd.Dock = DockStyle.Fill;
            panel4.Controls.Add(hd);
            Employeeuser.Dock = DockStyle.Fill;
            panel4.Controls.Add(Employeeuser);
            EmployeeForm.Instance.panel4_.Controls["Employee_user"].BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EmployeeForm.Instance.panel4_.Controls["Employee_user"].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //EmployeeForm.Instance.panel4_.Controls[]
            //EmployeeForm.Instance.panel4_.Controls["SPofNVusercontrol"].BringToFront();
            
           
            EmployeeForm.Instance.panel4_.Controls["SanPhamUserControl"].BringToFront();
            sanpham.ShowSP();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeForm.Instance.panel4_.Controls["Hoadon"].BringToFront();
            
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginform a = new Loginform();
            a.Show();
        }
    }
}
