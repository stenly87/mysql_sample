using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new GenderDB();
            db.AddGender("не определился");
            var genders = db.GetGenders();
            /*db.DeleteGender(genders[2]);
            db.DeleteGender(genders[3]);
            genders = db.GetGenders();*/
            //genders[2].Title = "все еще не определился";
            /*db.UpdateGender(genders[2]);
            genders = db.GetGenders();*/


            Console.WriteLine("Результаты:");
            foreach (var gender in genders)
                Console.WriteLine($"id: {gender.ID} title: {gender.Title}");
        }
    }

    public class Gender
    { 
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
