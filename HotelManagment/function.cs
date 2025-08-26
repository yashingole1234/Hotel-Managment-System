using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagment
{
    internal class function
    {
        protected SqlConnection getConnetion() 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = YASHINGOLE;database=myHotel;integrated security=True";
            return con;
        }
        public DataSet getData(String query) //Get Data From Database
        {
            SqlConnection con = getConnetion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(String query, String  message) // Inserting Deletion And Updation
        {

            SqlConnection con = getConnetion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'"+ message +"'","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public SqlDataReader getForcombo(string query)
        {
            SqlConnection con = getConnetion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }        
}