using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMgmt1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void licensing1_Load(object sender, EventArgs e)
        {

        }

        private void Resetlb_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            PasswordTb.Text="";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("missing Data!!");
            }
            else if(UNameTb.Text == "Admin" || PasswordTb.Text == "Password")
            {
                Employees obj= new Employees();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
                UNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }
    }
}
