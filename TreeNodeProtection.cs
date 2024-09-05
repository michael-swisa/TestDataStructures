namespace TestDataStructures
{
    internal class TreeNodeProtection
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public TreeNodeProtection Right { get; set; }
        public TreeNodeProtection Left { get; set; }

        public TreeNodeProtection(int minSeverity, int maxSeverity, List<string> defenses)
        {
            this.MinSeverity = minSeverity;
            this.MaxSeverity = maxSeverity;
            this.Defenses = defenses;
            this.Right = null;
            this.Left = null;
        }
    }
}
