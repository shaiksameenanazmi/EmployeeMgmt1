using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMgmt1
{
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }
        private void ShowEmp()
        {
            try
            {
                string query = "select * from EmployeeTb";
                EmployeeList.DataSource = Con.GetData(query);
            }
            catch(Exception)
            {
                throw;
            }
        }
        private void GetDepartment()
        {
            string query = "select * from DepartmentTb";
            DepCb.DisplayMember = Con.GetData(query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString(); // Assuming GenCb is initialized

                    int Dep = 0; // Initialize to a default value
                    if (DepCb.SelectedIndex > -1)
                    {
                        Dep = Convert.ToInt32(DepCb.SelectedValue); // Use SelectedValue directly
                    }
                    else
                    {
                        MessageBox.Show("Please select a department.");
                        return;
                    }

                    // Format DOB and JDate according to mm-dd-yyyy format
                    string DOB = DOBTb.Value.ToString("MM-dd-yyyy");
                    string JDate = JDateTb.Value.ToString("MM-dd-yyyy");

                    int salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "INSERT INTO EmployeeTb (EmpName, EmpGen, EmpDep, EmpDOB, EmpIDate, EmpSal) VALUES ('{0}', '{1}', {2}, '{3}', '{4}', {5})";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, salary);

                    Con.SetData(Query);
                    ShowEmp();
                        MessageBox.Show("Employee added!");
                        EmpNameTb.Text = "";
                        DailySalTb.Text = "";
                        GenCb.SelectedIndex = -1;
                        DepCb.SelectedIndex = -1;
                    }
                    }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {


                    string Query = "Delete from EmployeeTb where EmpId={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowEmp();
                        MessageBox.Show("Employee Deleted!");
                        EmpNameTb.Text = "";
                        DailySalTb.Text = "";
                        GenCb.SelectedIndex = -1;
                        DepCb.SelectedIndex = -1;
                    }
                    }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString(); // Get selected gender

                    int Dep = 0; // Initialize to a default value
                    if (DepCb.SelectedIndex > -1)
                    {
                        Dep = Convert.ToInt32(DepCb.SelectedValue); // Get selected department ID
                    }
                    else
                    {
                        MessageBox.Show("Please select a department.");
                        return;
                    }

                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "Update EmployeeTb set EmpName='{0}',EmpGen='{1}',EmpDep={2},EmpDOB='{3}',EmpIDate='{4}',EmpSal={5} where EmpId={6}";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, salary,key);
                    Con.SetData(Query);
                    ShowEmp();
                        MessageBox.Show("Employee added!");
                        EmpNameTb.Text = "";
                        DailySalTb.Text = "";
                        GenCb.SelectedIndex = -1;
                        DepCb.SelectedIndex = -1;
                    }
                    }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = EmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            DepCb.SelectedValue = EmployeeList.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = EmployeeList.SelectedRows[0].Cells[4].Value.ToString();
            JDateTb.Text = EmployeeList.SelectedRows[0].Cells[5].Value.ToString();
            DailySalTb.Text = EmployeeList.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeeList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
        private void label12_Click(object sender, EventArgs e)
        {
            Salaries salary=new Salaries();
            salary.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Salaries salary = new Salaries();
            salary.Show();
            this.Hide();
        }
    }





}
