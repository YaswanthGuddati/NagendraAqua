using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NagendraAqua.Models
{
    public class CustomerDAL
    {
        SqlConnection con =
           new SqlConnection(ConfigurationManager
           .ConnectionStrings["dbcs"].ConnectionString);

        // =============================
        // INSERT CUSTOMER
        // =============================
        public void InsertCustomer(Customer c)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
            cmd.Parameters.AddWithValue("@Address", c.Address);
            cmd.Parameters.AddWithValue("@Mobile", c.Mobile);
            cmd.Parameters.AddWithValue("@FeedId", c.FeedId);
            cmd.Parameters.AddWithValue("@CustomerType", c.CustomerType);
            cmd.Parameters.AddWithValue("@SellerId", c.SellerId);
            //cmd.Parameters.AddWithValue("@Quantity", c.Quantity);
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = c.Quantity;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // =============================
        // GET ALL CUSTOMERS
        // =============================
        public DataTable GetCustomers()
        {
            SqlCommand cmd = new SqlCommand("sp_GetCustomers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        //// =============================
        //// GET CUSTOMER BY ID (EDIT)
        //// =============================
        //public Customer GetCustomerById(int id)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_GetCustomerById", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@CustomerId", id);

        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    Customer c = new Customer();

        //    if (dr.Read())
        //    {
        //        c.CustomerId = (int)dr["CustomerId"];
        //        c.CustomerName = dr["CustomerName"].ToString();
        //        c.Address = dr["Address"].ToString();
        //        c.Mobile = dr["Mobile"].ToString();
        //        c.FeedId = (int)dr["FeedId"];
        //        c.CustomerType = dr["CustomerType"].ToString();
        //        c.SellerId = (int)dr["SellerId"];
        //        c.Date = (System.DateTime)dr["OrderDate"];
        //    }

        //    con.Close();
        //    return c;
        //}

        //// =============================
        //// UPDATE CUSTOMER
        //// =============================
        //public void UpdateCustomer(Customer c)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@CustomerId", c.CustomerId);
        //    cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
        //    cmd.Parameters.AddWithValue("@Address", c.Address);
        //    cmd.Parameters.AddWithValue("@Mobile", c.Mobile);
        //    cmd.Parameters.AddWithValue("@FeedId", c.FeedId);
        //    cmd.Parameters.AddWithValue("@CustomerType", c.CustomerType);
        //    cmd.Parameters.AddWithValue("@SellerId", c.SellerId);
        //    cmd.Parameters.AddWithValue("@Quantity", c.Quantity);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        // =============================
        // DELETE CUSTOMER
        // =============================
        public void DeleteCustomer(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerId", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}