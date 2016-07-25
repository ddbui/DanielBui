using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseJsonFromFile();

            SerializeJson();

            Console.ReadLine();
        }

        private static void SerializeJson()
        {
            var heading = new Heading
            {
                DateTime = DateTime.Now,
                Activity = "Current Activity",
                Channel  = "Channel 1",
                Unknown  = "1.47E-004 uCi/cc",
                Detector = "RD-52 Detector",
                FlowMask = "00E+000 SCFM"
            };

            using (StreamWriter file = File.CreateText(@"heading.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, heading);
            }
        }

        private static void ParseJsonFromFile()
        {
            JsonTextReader reader = new JsonTextReader(new StreamReader(@"C:\Users\buidan\Documents\Projects\RM-2300.json"));

            try
            {
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        Console.WriteLine("{0}: {1}, {2}", reader.LineNumber, reader.TokenType, reader.Value);
                    }
                    else
                    {
                        //Console.WriteLine("Token: {0}", reader.TokenType);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
