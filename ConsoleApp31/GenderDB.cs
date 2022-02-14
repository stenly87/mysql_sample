using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class GenderDB : MySqlDB
    {
        public List<Gender> GetGenders()
        {
            List<Gender> genders = new List<Gender>();
            if (OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM gender";
                    using (MySqlCommand mc = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader dr = mc.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                genders.Add(new Gender
                                {
                                    ID = dr.GetInt32("id"),
                                    Title = dr.GetString("title")
                                });
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                CloseConnection();
            }
            return genders;
        }

        public void AddGender(string title)
        {
            string query = "insert into gender values (0, @title)";
            ExecuteNonQuery(query, new[] { new MySqlParameter { ParameterName = "title", Value = title } });
        }

        public void UpdateGender(Gender gender)
        {
            string query = "update gender set title=@title where id = " + gender.ID;
            ExecuteNonQuery(query, new[] { new MySqlParameter { ParameterName = "title", Value = gender.Title } });
        }

        public void DeleteGender(Gender gender)
        {
            string query = "delete from gender where id = " + gender.ID;
            ExecuteNonQuery(query);
        }
    }
}
