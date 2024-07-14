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
    public partial class Salaries : Form
    {
        Functions Con;
        public Salaries()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalaries();
            GetEmployees();

        }

      
        private void GetEmployees()
        {
            string query = "select * from EmployeeTb";
            EmpCbn.DisplayMember = Con.GetData(query).Columns["EmpName"].ToString();
            EmpCbn.ValueMember = Con.GetData(query).Columns["EmpId"].ToString();
            EmpCbn.DataSource = Con.GetData(query);
        }
        int DSal = 0;
        string Period = "";
        private void GetSalary()
        {
            string query = "select EmpSal from EmployeeTb where EmpId={0}";
            query = string.Format(query, EmpCbn.SelectedValue.ToString());
            
            foreach(DataRow dr in Con.GetData(query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }
            if (DaysTb.Text=="")
            {
                AmountTb .Text="Rs " +  (d * DSal);
            }
            else if(Convert.ToInt32(DaysTb.Text)>31)
            {
                MessageBox.Show("Days can not be greater than 31");
            }
            else
            {
                d=Convert.ToInt32(DaysTb.Text);
                AmountTb.Text = "Rs " + (d * DSal);
            }
        }

        private void ShowSalaries()
        {
            try
            {
                string query = "select * from SalaryTb";
                SalaryList.DataSource = Con.GetData(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SalaryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int d = 1;

        private void AddBtn_Click(object sender, EventArgs e)
        {
           try
            {
                if (EmpCbn.SelectedIndex == -1 || DaysTb.Text == "" || PeriodTb.Text == "")
                {
                    MessageBox.Show("missing data!!");
                }
                else
                {
                    Period = PeriodTb.Value.Date.Month.ToString() + "-" + PeriodTb.Value.Date.Year.ToString();
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int Days= Convert.ToInt32(DaysTb.Text);
                    
                    string Query = "INSERT INTO SalaryTb VALUES ({0}, {1}, '{2}', {3}, '{4}')";
                    Query = string.Format(Query,EmpCbn.SelectedValue.ToString(),Days,Period,Amount,DateTime.Today.Date);

                    Con.SetData(Query);
                    ShowSalaries();
                    MessageBox.Show("Salary Paid");
                    DaysTb.Text = "";
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }

        private void AmountTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Logoutlb_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Departments departments = new Departments();
            departments.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
            this.Hide();
        }
    }
}
