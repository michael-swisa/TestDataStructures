using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestDataStructures.Models
{
    internal class Threats
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        private static Dictionary<string, int> ConversionThreatTypeDictionary = new Dictionary<
            string,
            int
        >()
        {
            { "Web Server", 10 },
            { "Database", 15 },
            { "User Credentials", 20 }
        };

        public int GetConversion()
        {
            try
            {
                return ConversionThreatTypeDictionary[ThreatType];
            }
            catch
            {
                return 5;
            }
        }
    }
}
