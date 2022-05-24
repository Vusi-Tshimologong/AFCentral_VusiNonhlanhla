using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class SqlServerAccess
    {

        public string ConnectionString { get; init; }

        public SqlServerAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }


        public string ConnectToDB(string firstName, string surname, string printerCode)

        {

            string msg = "unsuccessful";

            using (SqlConnection cn = new SqlConnection() )
            {
                cn.ConnectionString = ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsert_Facilitator";

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@FirstName";
                    param.Value = firstName;

                    cmd.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@Surname";
                    param2.Value = surname;

                    cmd.Parameters.Add(param2);

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@PrinterCode";
                    param3.Value = printerCode;

                    cmd.Parameters.Add(param3);

                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@Msg";
                    param4.Value = String.Empty;

                    cmd.Parameters.Add(param4);


                    cmd.ExecuteNonQuery();

                    return "success";
                }
            }
            return msg;
        }
    }
}
