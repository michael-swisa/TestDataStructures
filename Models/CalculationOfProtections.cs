using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataStructures.Models
{
    internal class CalculationOfProtections
    {
        public int SeverityCalcultion(Threats thread)
        {
            int severity = thread.Volume * thread.Sophistication + thread.GetConversion();

            return severity;
        }
    }
}
