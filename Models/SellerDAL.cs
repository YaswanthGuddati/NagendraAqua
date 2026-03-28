using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace NagendraAqua.Models
{
    public class SellerDAL
    {
        SqlConnection con =
            new SqlConnection(ConfigurationManager
            .ConnectionStrings["dbcs"].ConnectionString);

        // =============================
        // INSERT SELLER
        // =============================
        public void InsertSeller(Seller s)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerName", s.SellerName);
            cmd.Parameters.AddWithValue("@Password", s.Password);
            cmd.Parameters.AddWithValue("@Role", "Seller");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // =============================
        // GET SELLERS
        // =============================
        public List<Seller> GetSellers()
        {
            SqlCommand cmd = new SqlCommand("sp_GetSellers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Seller> list = new List<Seller>();

            while (dr.Read())
            {
                list.Add(new Seller
                {
                    SellerId = (int)dr["SellerId"],
                    SellerName = dr["SellerName"].ToString(),
                    Password = dr["Password"].ToString(),
                    Role = dr["Role"].ToString()
                });
            }

            con.Close();
            return list;
        }

        // =============================
        // DELETE SELLER
        // =============================
        public void DeleteSeller(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SellerId", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}