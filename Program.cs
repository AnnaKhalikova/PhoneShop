using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Phone_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! You at the phone shop!");
        }
        static JObject ReadJSONFromFile(string path)
        {
            JObject o2;
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"c:\videogames.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                o2 = (JObject)JToken.ReadFrom(reader);
            }

            return o2;
        }
    }
}
