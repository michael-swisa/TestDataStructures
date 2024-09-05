using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataStructures
{
    internal class BinaryTreeProtection
    {
        private TreeNodeProtection _root;

        public BinaryTreeProtection()
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
    }
}
