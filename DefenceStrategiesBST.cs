using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestDataStructures
{
    internal class DefenceStrategiesBST
    {
        private TreeNodeProtection _root;

        public DefenceStrategiesBST()
        {
            this._root = null;
        }

        public void Insert(int minSeverity, int maxSeverity, List<string> defenses)
        {
            _root = InsertRecursive(_root, minSeverity, maxSeverity, defenses);
        }

        private TreeNodeProtection InsertRecursive(
            TreeNodeProtection node,
            int minSeverity,
            int maxSeverity,
            List<string> defenses
        )
        {
            if (node == null)
            {
                node = new TreeNodeProtection(minSeverity, maxSeverity, defenses);
                return node;
            }
            if (minSeverity < node.MinSeverity)
                node.Left = InsertRecursive(node.Left, minSeverity, maxSeverity, defenses);
            else // value >= node.Value
                node.Right = InsertRecursive(node.Right, minSeverity, maxSeverity, defenses);
            return node;
        }

        public DefenceStrategiesBST LoadFromJson(string filePath)
        {
            // טעינת הקובץ json
            string jsonString = File.ReadAllText(filePath);

            // המרה של הקובץ json לליסט של הרבה nodes
            List<TreeNodeProtection>? defenceStrategies = JsonSerializer.Deserialize<
                List<TreeNodeProtection>
            >(jsonString);

            // יצירת עץ בינארי חדש
            DefenceStrategiesBST root = new DefenceStrategiesBST();

            foreach (TreeNodeProtection defenceStrategy in defenceStrategies)
            {
                root.Insert(
                    defenceStrategy.MinSeverity,
                    defenceStrategy.MaxSeverity,
                    defenceStrategy.Defenses
                );
            }
            return root;
        }
    }
}
