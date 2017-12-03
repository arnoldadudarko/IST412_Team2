using System;

public class PieChart
{
    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("MockData.json"))
        {
            string json = r.ReadToEnd();
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
    }
    dynamic array = JsonConvert.DeserializeObject(json);
}

