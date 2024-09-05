namespace TestDataStructures
{
    internal class TreeNode
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Left { get; set; }

        public TreeNode(int minSeverity, int maxSeverity, List<string> defenses)
        {
            MinSeverity = minSeverity;
            this.MaxSeverity = maxSeverity;
            this.Defenses = defenses;
            this.Right = null;
            this.Left = null;
        }
    }
}
