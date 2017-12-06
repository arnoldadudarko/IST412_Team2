using System;
namespace CloudApp
{

    public class PieChart
    {
        public PieChart()
        {
            string[] components = System.IO.File.ReadAllLines(@"C:\Users\Arnold Adu-Darko\Desktop\MockData.json");
            System.Console.WriteLine("Components: ");
            foreach (string line in components)
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("Press a key to exit");
            System.Console.ReadKey();
        }   
    }
}
