using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestDataStructures.Models
{
    internal static class LoadThreats
    {
        public static List<Threats> LoadFromJson(string filePath)
        {
            // טעינת הקובץ json
            string jsonString = File.ReadAllText(filePath);

            // המרה של הקובץ json לליסט של הרבה threads
            List<Threats>? threadsList = JsonSerializer.Deserialize<List<Threats>>(jsonString);

            return threadsList;
        }
    }
}
