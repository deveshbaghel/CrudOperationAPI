using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MvcApplication2.DataAccessLayer
{
    public class Home
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        SqlCommand cmd;
        int result;

        public string InsertData(Employee objCust)
        {
            try
            {
                cmd = new SqlCommand("Proc_Inserts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", objCust.Name);
                cmd.Parameters.AddWithValue("@Email", objCust.Email);
                cmd.Parameters.AddWithValue("@Mobile", objCust.Mobile);
                cmd.Parameters.AddWithValue("@Address", objCust.Address);
                con.Open();
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return "Record Save Successfully.";
                else
                    return "Record Not save";
            }
            catch
            {
                return "Record Not save";
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable Getdata()
        {
            List<Employee> obj = new List<Employee>();
            DataTable dtt = new DataTable();
            SqlDataAdapter dt = new SqlDataAdapter();
            con.Open();
            cmd = new SqlCommand("select * from Employee order by Name", con);
            dt.SelectCommand = cmd;
            dt.Fill(dtt);
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                Employee GetAll = new Employee();
                GetAll.Name = dtt.Rows[i]["name"].ToString();
                GetAll.Address = dtt.Rows[i]["address"].ToString();
                GetAll.Email = dtt.Rows[i]["email"].ToString();
                GetAll.Mobile = Convert.ToInt64(dtt.Rows[i]["Mobile"].ToString());
                obj.Add(GetAll);
            }
            dt.Dispose();
            con.Close();
            return dtt;
        }
        public int Delete(string id)
        {
            con.Open();
            cmd = new SqlCommand("delete  from Employee where id='" + id + "'", con);
            int dt = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return dt;
        }
    }
}