using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
namespace HotelManagment.All_User_Control
{
    public partial class UC_Customer_Registration : System.Windows.Forms.UserControl
    {
        function fn = new function();
        String query;


        public UC_Customer_Registration()
        {
            InitializeComponent();
        }

        public void setCombobox(String query,ComboBox combo)
        {
            SqlDataReader sdr = fn.getForcombo(query);  
            while (sdr.Read())
            {
                for(int i=0; i< sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));  
                }
            }
            sdr.Close();
        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
            query = "select roomNo from rooms where bed = '" + txtBed.Text + "' and roomType= '" + txtRoom.Text + "' and booked = 'NO'";
            setCombobox(query, txtRoomNo);
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear ();
            txtPrice.Clear();
        }

        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query="select price,roomid from rooms where roomNo ='"+txtRoomNo.Text+"'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }
        
        private void txtAlloteRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDOB.Text != "" && txtidproof.Text != "" && txtAddress.Text != "" && txtCheckIn.Text != "" && txtPrice.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String nationality = txtNationality.Text;
                String gender = txtGender.Text;
                String DOB = txtDOB.Text;
                String idproof = txtidproof.Text;
                String address = txtAddress.Text;
                String checkIn = txtCheckIn.Text;

                query = "insert into customer (cname,mobile,nationality,gender,dob,idproof,address,checkin,roomid) values ('" + name + "' ,'" + mobile + "' , '" + nationality + "' , '" + gender + "' , '" + DOB + "', '" + idproof + "', '" + address + "' , '" + checkIn + "' , " + rid + ")update rooms set booked ='YES' where roomNo= '" + txtRoomNo.Text + "'";
                fn.setData(query, "Room No" + txtRoomNo.Text + " Allocation Successful.");
                clearAll();
            }
            else
            {
                MessageBox.Show("All fields are mandetory.", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDOB.ResetText();
            txtidproof.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();

        }

        private void UC_Customer_Registration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

      
    }
}    