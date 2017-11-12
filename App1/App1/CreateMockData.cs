using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

// Kelby Chen
// Create Mock JSON data
// 11/11/2017

namespace Team2_IST412
{
    public class CreateMockData
    {
        static void Main(string[] args)
        {
            //Used for randomizing data
            Random rnd = new Random();

            //List for events
            var event_list = new List<String>
            {
                "Temp",
                "Motion",
                "Noise",
                "Light",
                "Button"
            };

            //List for emails
            var email_list = new List<String>
            {
                "dev1@gmail.com",
                "dev2@gmail.com",
                "dev3@gmail.com",
                "dev4@gmail.com",
                "dev5@gmail.com"
            };

            //Create list to hold JSON data for insertion into file
            List<Data> db = new List<Data>();

            //Creates 50 data randomized JSON data entries
            for (int i = 0; i <= 50; i++)
            {
                string team = "Team " + rnd.Next(1, 5);
                string device = "RP " + rnd.Next(1, 5);
                string events = event_list[rnd.Next(event_list.Count)];
                string time = RandomTime();
                string day = RandomDay();
                string email = email_list[rnd.Next(email_list.Count)];
                
                //Generate Unit Temp or Bool depending on event type
                string n = "";
                if (events == "Temp")
                {
                    n = "" + rnd.Next(0, 100);
                }
                else
                {
                    n = "" + rnd.Next(0, 1);
                }
                string unit = n;

                //Create data object and inset into db list
                Data data = new Data
                {
                    Team = team,
                    Device = device,
                    Event = events,
                    Time = time,
                    Date = day,
                    Email = email,
                    Value = unit
                };
                db.Add(data);
            }

            //Writes to MockData.json file
            File.WriteAllText(@"MockData.json", JsonConvert.SerializeObject(db));
        }

        static String RandomDay()
        {
            //Generates random day
            Random rnd = new Random();
            DateTime start = new DateTime(2017, 11, 12);
            int range = (DateTime.Today - start).Days;
            DateTime date = start.AddDays(rnd.Next(range));
            string str_date = date.ToString();
            return str_date;
        }

        static String RandomTime()
        {
            //Generates random time stamp
            Random rnd = new Random();
            int hh = rnd.Next(0, 24);
            int mm = rnd.Next(0, 60);
            int ss = rnd.Next(0, 60);
            int ms = rnd.Next(0, 999);
            string time = "" + hh + mm + ss + ms;
            return time;
        }

    }

    public class Data
    {
        //Team ID
        public string Team { get; set; }
        //Device ID
        public string Device { get; set; }
        //Events
        public string Event { get; set; }
        //Time Stamp
        public string Time { get; set; }
        //Date
        public string Date { get; set; }
        //Email Address
        public string Email { get; set; }
        //Unit Value
        public string Value { get; set; }
    }
}