using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataStructures.Models
{
    internal class ActivationAttacks
    {
        private DefenceStrategiesBST _root;

        public ActivationAttacks(string filePath)
        {
            _root = new DefenceStrategiesBST();
            _root = _root.LoadFromJson(filePath);
        }

        // O(n)
        public async Task StartAttack(Threats thread)
        {
            int severity = thread.Volume * thread.Sophistication + thread.GetConversion();
            TreeNodeProtection result = _root.Find(severity);
            if (result == null)
            {
                int? minSeverity = _root.GetMin();
                if (severity < minSeverity)
                {
                    Console.WriteLine("Attack is ignored Attack severity is below the threshold.");
                }
                else
                {
                    Console.WriteLine("The attack was good, no suitable defense was found.");
                }
                await Task.Delay(2000);
            }
            if (result != null)
            {
                foreach (var item in result.Defenses)
                {
                    Console.WriteLine($"Threat: {thread.ThreatType}, Defense: {item}");
                    await Task.Delay(2000);
                }
            }
        }
    }
}
