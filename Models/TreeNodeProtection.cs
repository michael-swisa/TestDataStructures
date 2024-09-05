namespace TestDataStructures.Models
{
    internal class TreeNodeProtection
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public TreeNodeProtection? Right { get; set; }
        public TreeNodeProtection? Left { get; set; }

        public TreeNodeProtection() { }

        public TreeNodeProtection(int minSeverity, int maxSeverity, List<string> defenses)
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defenses = defenses;
            Right = null;
            Left = null;
        }
    }
}
