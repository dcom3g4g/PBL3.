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
        static EmployeeForm _obj;
        public Employee_user Employeeuser = new Employee_user();
        public sanpham sp = new sanpham();
        public Hoadon hd = new Hoadon();

        public static EmployeeForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new EmployeeForm();
                }
                return _obj;
            }
        }
        public Panel panel4_
        {
            get { return panel4; }
            set { panel4 = value; }
        }
        public EmployeeForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = this;
          
            Employeeuser.Dock = DockStyle.Fill;
            panel4.Controls.Add(sp);
            Employeeuser.Dock = DockStyle.Fill;
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
            EmployeeForm.Instance.panel4_.Controls["sanpham"].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeForm.Instance.panel4_.Controls["Hoadon"].BringToFront();
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
