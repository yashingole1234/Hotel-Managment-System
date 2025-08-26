using HotelManagment.All_User_Control;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            MovingPanel.Left=btnCustomerRegistration.Left+24;
            uC_CustomerRegistration1.Visible=true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void btmAddRoom_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btmAddRoom.Left+16;
           uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

            uC_Customer_CheckOut1.Visible = true;
            uC_Customer_CheckOut1.BringToFront();

            MovingPanel.Left = btnCheckOut.Left+16;
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible = true;
            customerDetails1.BringToFront();
            MovingPanel.Left = btnCustomerDetails.Left + 16;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();

            MovingPanel.Left =btnEmployee.Left + 16;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;   
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Employee1.Visible = false;
            uC_AddRoom1.Visible=false;
            uC_CustomerRegistration1.Visible=false; 
            btmAddRoom.PerformClick();
        }
    }
}
