using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HotelManagment.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        string query;
        public UC_Employee()
        {
            InitializeComponent();
        }


        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 0)
            {
               setEmployee(guna2DataGridView3);
            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                setEmployee(guna2DataGridView4);
            }
        }
        private void btnButton_Click(object sender, EventArgs e)
        {
            if (txtaName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                String name = txtaName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String userName = txtUserName.Text;
                String password = txtPassword.Text;

                query = "insert into employee (ename,mobile,gender,emailid,username,pass) values ('" + name + "','" + mobile + "','" + gender + "','" + email + "','" + userName + "','" + password + "')";
                fn.setData(query, "Employee Registered.");

                ClearAll();
                getMaxID();
            }
            else
            {
                MessageBox.Show("Fill all Fields.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtID.Text !="")
            {
                if(MessageBox.Show("Are You Sure?", "Conformation...!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {

                }
            }
            query = "delete from employee where eid =" + txtID.Text + "";
            fn.setData(query,"Record Deleated.");
            tabEmployee_SelectedIndexChanged(this,null);
        }
        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }

        public void getMaxID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }

        }
        public void ClearAll()
        {
            txtaName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();

        }

      public void setEmployee(DataGridView dgv)
        {
            query = "Select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

       
    }
}
        
