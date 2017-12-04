using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

// Editor: Win Ton
// Works Cited: 
// https://stackoverflow.com/questions/7980456/reading-from-a-text-file-in-c-sharp
// https://stackoverflow.com/questions/18100783/how-to-convert-a-list-into-data-table
// https://stackoverflow.com/questions/13297563/read-and-parse-a-json-file-in-c-sharp
//
// Purpose: This file read a JSON file into a List and then converts the List into a Table

namespace CloudApp
{
    public class DataTable
    {

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                List<Data> data = JsonConvert.DeserializeObject<List<Data>>(json);
            }
        }

        public class Data
        {
            public int temperature;
            public int noise;
            public int motion;
            public int light;
            public int temperatureAverage;
            public int noiseAverage;
            public int motionAverage;
            public int lightAverage;

            // There will be an average value calculator.
            // It will append each value to an array and then calculate the average of the array.

        }

        public static DataTable ToDataTable<Table>(List<Table> data)
        {
            DataTable dataTable = new DataTable(typeof(Table).Data);

            //Get all the properties
            DataInfo[] Data = typeof(Table).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (DataInfo temperatureAverage in Data)
            {
                //Defining type of data column gives proper data table 
                var type = (temperatureAverage.DataType.IsGenericType && temperatureAverage.DataType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(temperatureAverage.DataType) : temperatureAverage.DataType);
                //Setting column names as Property names
                dataTable.Columns.Add(temperatureAverage.Name, type);
            }

            // Still working on this part.
            foreach (Table item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}
