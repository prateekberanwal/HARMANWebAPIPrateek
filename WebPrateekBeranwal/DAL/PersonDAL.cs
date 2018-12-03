using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonDAL
    {
        public DataSet getPersonDetail(int id)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("[GetPerson]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int SavePerson(PersonModel person)
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertPerson", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ForeName", SqlDbType.VarChar).Value = person.ForeName;
                    cmd.Parameters.Add("@SurName", SqlDbType.VarChar).Value = person.SurName;
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = person.DOB;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = person.Gender;
                    if (person.Number.Count > 0)
                    {
                        cmd.Parameters.Add("@HomeNumber", SqlDbType.VarChar).Value = person.Number[0].Number;
                        cmd.Parameters.Add("@WorkNumber", SqlDbType.VarChar).Value = person.Number[1].Number;
                        cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = person.Number[2].Number;
                    }
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            return Convert.ToInt16(ds.Tables[0].Rows[0][0]);
        }


    }
}

