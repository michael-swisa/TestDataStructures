using System.Text.Json;

namespace TestDataStructures.Models
{
    internal class DefenceStrategiesBST
    {
        private TreeNodeProtection _root;

        public DefenceStrategiesBST()
        {
            _root = null;
        }

        // O(log(n))
        public void Insert(int MinSeverity, int MaxSeverity, List<string> Defenses)
        {
            _root = InsertRecursive(_root, MinSeverity, MaxSeverity, Defenses);
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

        // O(n)
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

        // O(n)
        public void PrintTree()
        {
            PrintTree(_root, "", true);
        }

        // O(n)
        private void PrintTree(TreeNodeProtection node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└──Right");
                    indent += "   ";
                }
                else
                {
                    Console.Write("├──Left");
                    indent += "│  ";
                }
                Console.WriteLine(
                    $" Child: [{node.MinSeverity}-{node.MaxSeverity}] Defenses: {string.Join(", ", node.Defenses)}"
                );
                PrintTree(node.Left, indent, false);
                PrintTree(node.Right, indent, true);
            }
        }

        // O(log(n))
        public TreeNodeProtection Find(int value)
        {
            return FindRecursive(_root, value);
        }

        // O(log(n))
        private TreeNodeProtection FindRecursive(TreeNodeProtection node, int value)
        {
            if (node == null)
                return null;

            if (node.MinSeverity <= value && node.MaxSeverity >= value)
                return node;

            if (value < node.MinSeverity)
                return FindRecursive(node.Left, value);

            return FindRecursive(node.Right, value);
        }

        // O(log(n))
        public int? GetMin()
        {
            return GetMinRecursive(_root);
        }

        private int? GetMinRecursive(TreeNodeProtection node)
        {
            if (node == null)
                return null;

            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.MinSeverity;
        }

        //public DefenceStrategiesBST constructBalancedTree(List<TreeNodeProtection> values, int min, int max)
        //{
        //    if (min == max)
        //        return null;

        //    int median = min + (max - min) / 2;
        //    return new TreeNode
        //    {
        //        Value = values[median],
        //        Left = constructBalancedTree(values, min, median),
        //        Right = constructBalancedTree(values, median + 1, max)
        //    };
        //}

        //public DefenceStrategiesBST constructBalancedTree(IEnumerable<int> values)
        //{
        //    return constructBalancedTree(
        //        values.OrderBy(x => x).ToList(), 0, values.Count());
        //}
    }
}
