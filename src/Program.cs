using System;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApplication
{

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("./data/reducedInput.json");
            
            DataFile data = (DataFile) JsonConvert.DeserializeObject<DataFile>(input);

            string output = JsonConvert.SerializeObject(data);
            
            Console.WriteLine("Input: ");
            Console.WriteLine(input);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }
    }
}
