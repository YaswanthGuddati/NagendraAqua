using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NagendraAqua.Models
{
    public class AdminDAL
    {
        SqlConnection con = new SqlConnection(
           ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);

        public bool AdminLogin(Admin a)
        {
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerName", a.SellerName);
            cmd.Parameters.AddWithValue("@Password", a.Password);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            bool status = dr.HasRows;

            con.Close();
            return status;
        }
    }
}