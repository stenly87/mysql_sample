using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class MySqlDB
    {
        protected MySqlConnection sqlConnection = null;

        void InitConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = "student";
            builder.Password = "student";
            builder.Database = "1125_human";
            builder.Server = "192.168.1.12";
            builder.CharacterSet = "utf8";
            builder.ConnectionTimeout = 5;

            sqlConnection = new MySqlConnection(builder.GetConnectionString(true));
        }

        protected bool OpenConnection()
        {
            try
            {
                if (sqlConnection == null)
                    InitConnection();
                sqlConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        protected void CloseConnection()
        {
            try
            {
                sqlConnection.Close(); // закрытие соединения
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            if (OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, sqlConnection))
                {
                    if (parameters != null)
                        mc.Parameters.AddRange(parameters);
                    mc.ExecuteNonQuery();
                }
                CloseConnection();
            }
        }

        
    }
}
