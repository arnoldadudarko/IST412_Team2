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
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                List items = JsonConvert.DeserializeObject<List>(json);
            }
        }
    }

    internal class List
    {
    }
}