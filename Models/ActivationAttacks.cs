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

        public async Task StartAttack(Threats thread)
        {
            int severity = thread.Volume * thread.Sophistication + thread.GetConversion();
            List<string> result = _root.Find(severity);
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"Threat: {thread.ThreatType}, Defense: {item}");
                    await Task.Delay(2000);
                }
            }
        }
    }
}
