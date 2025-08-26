using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagment
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        //private void label1_Click(object sender, EventArgs e)
       // {

       // }

       // private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
       // {

      //  }

       // private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        //{

        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query= "Select username,pass from employee where username ='"+txtUsername.Text+"' and pass = '"+txtPassword.Text+"'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count !=0)
            {

                labelError.Visible = false;
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();

            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }

        }
    }
}