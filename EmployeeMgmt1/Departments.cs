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
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();
        }
        private void ShowDepartments()
        {
            string query = "select * from DepartmentTb";
            DepList.DataSource= Con.GetData(query);
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text=="")
                {
                    MessageBox.Show("missing Data!!");
                }
                else
                {
                    string dep = DepNameTb.Text;
                    string Query="insert into DepartmentTb values('{0}')";
                    Query = string.Format(Query,DepNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("department addedd!!!");
                    DepNameTb.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int key = 0;
        private void DepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = DepList.SelectedRows[0].Cells[1].Value.ToString();
            if(DepNameTb.Text =="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DepList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("missing Data!!");
                }
                else
                {
                    string dep = DepNameTb.Text;
                    string Query = "update DepartmentTb set DepName ='{0}'where DepId='{1}'";
                    Query = string.Format(Query, DepNameTb.Text,key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("department Updated!!!");
                    DepNameTb.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("missing Data!!");
                }
                else
                {
                    string dep = DepNameTb.Text;
                    string Query = "Delete from DepartmentTb where DepId='{0}'";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("department Deleted!!!");
                    DepNameTb.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmplLbi_Click(object sender, EventArgs e)
        {

            Employees obj=new Employees();
            obj.Show();
            this.Hide();
        }

        private void Salarylb1_Click(object sender, EventArgs e)
        {
            Salaries obj=new Salaries();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login obj=new Login();
            obj.Show();
            this.Hide();
        }
    }
}
