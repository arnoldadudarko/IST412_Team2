using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CloudApp
{
    public class BarGraph
    {
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("MockData.json"))
            {
                string json = r.ReadToEnd();
                Data items = JsonConvert.DeserializeObject<Data>(json);
                Console.WriteLine(json);
            }
        }
        public class Data
        {
            public String team;
            public String device;
            public String Event;
            public int time;
            public int date;
            public String email;
            public int value;
        }
    }
}