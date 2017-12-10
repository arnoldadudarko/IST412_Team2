using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Used for randomizing data
            Random rnd = new Random();

            //List for Events
            var event_list = new List<String>
            {
                "Temp",
                "Motion",
                "Noise",
                "Light",
                "Button"
            };

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

            for (int i = 0; i <= 49; i++)
            {
                System.Threading.Thread.Sleep(100);
                string team = "Team " + rnd.Next(1, 5);
                string device = "RP " + rnd.Next(1, 5);
                string events = event_list[rnd.Next(event_list.Count)];
                string time = RandomTime();
                string date = RandomDay();
                string email = email_list[rnd.Next(email_list.Count)];
                
                //Generate Unit Temp or Bool
                string n = "";
                if (events == "Temp")
                {
                    n = "" + rnd.Next(0, 100);
                }
                else
                {
                    n = "" + rnd.Next(0, 2);
                }
                string unit = n;

                Data data = new Data
                {
                    Team = team,
                    Device = device,
                    Event = events,
                    Time = time,
                    Date = date,
                    Email = email,
                    Value = unit
                };
                
                db.Add(data);
                Console.WriteLine("New entry added: " + i);
            }
            
            //Display JSON data in Console
            string output = JsonConvert.SerializeObject(db.ToArray(), Formatting.Indented);
            Console.WriteLine(output);

            //Write to file
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktopPath += "\\MockData.json";
            System.IO.File.WriteAllText(desktopPath, output);

            //Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static String RandomDay()
        {
            Random rnd = new Random();
            int range = 1 * 365;
            DateTime date = DateTime.Today.AddDays(-rnd.Next(range));
            string str_date = date.ToString("MM/dd/yyyy");
            return str_date;
        }

        static String RandomTime()
        {
            Random rnd = new Random();
            int hh = rnd.Next(0, 24);
            int mm = rnd.Next(0, 60);
            int ss = rnd.Next(0, 60);
            int ms = rnd.Next(0, 999);
            string time = hh + ":" + mm + ":" + ss + ":" + ms;
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
