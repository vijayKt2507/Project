using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Shop.Models;


namespace Shop.ADo.netconnection
{
    public class connection
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public List<Sale> Getusers()
        {
            cmd = new SqlCommand("sp_Select_dress", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Sale> list = new List<Sale>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Sale
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    price = Convert.ToInt32(dr["price"]),
                    contact_Number = dr["contact_Number"].ToString(),
                    size= dr["Size"].ToString()


                });

            }
            return list;
        }
        public bool Insertuser(Sale user)
        {
            try
            {
                cmd = new SqlCommand("sp_insert_dress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@price", user.price);
                cmd.Parameters.AddWithValue("@contact_Number", user.contact_Number);
                cmd.Parameters.AddWithValue("@Size", user.size);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Updatetuser(Sale user)
        {
            cmd = new SqlCommand("sp_Update_dress", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@price", user.price);
            cmd.Parameters.AddWithValue("@contact_Number", user.contact_Number);
            cmd.Parameters.AddWithValue("@Size", user.size);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            try
            {

            }
            catch (SqlException)
            {

                throw;
                con.Close();
            }
        }
        public int Deletetuser(int id)
        {
            try
            {
                cmd = new SqlCommand("sp_remove", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                return cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}