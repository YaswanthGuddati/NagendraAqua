using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NagendraAqua.Models
{
    public class FeedDAL
    {
        SqlConnection con =
            new SqlConnection(ConfigurationManager
            .ConnectionStrings["dbcs"].ConnectionString);

        // =========================
        // GET ALL FEEDS
        // =========================
        public List<Feed> GetFeeds()
        {
            SqlCommand cmd = new SqlCommand("sp_GetFeeds", con);
            cmd.CommandType = CommandType.StoredProcedure;

            List<Feed> feeds = new List<Feed>();

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                feeds.Add(new Feed()
                {
                    FeedId = (int)dr["FeedId"],
                    FeedName = dr["FeedName"].ToString()
                });
            }

            con.Close();
            return feeds;
        }

        // =========================
        // INSERT
        // =========================
        public void InsertFeed(Feed f)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertFeed", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FeedName", f.FeedName);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // =========================
        // UPDATE
        // =========================
        public void UpdateFeed(Feed f)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateFeed", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FeedId", f.FeedId);
            cmd.Parameters.AddWithValue("@FeedName", f.FeedName);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // =========================
        // DELETE
        // =========================
        public void DeleteFeed(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteFeed", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FeedId", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // =========================
        // GET BY ID (EDIT)
        // =========================
        public Feed GetFeedById(int id)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Feed WHERE FeedId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Feed f = new Feed();

            if (dr.Read())
            {
                f.FeedId = (int)dr["FeedId"];
                f.FeedName = dr["FeedName"].ToString();
            }

            con.Close();
            return f;
        }
    }
}