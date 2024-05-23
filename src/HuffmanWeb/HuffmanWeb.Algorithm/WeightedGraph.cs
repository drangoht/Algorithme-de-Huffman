namespace HuffmanWeb.Algorithm
{
    public class WeightedGraph
    {
        public HuffmanNode? Root { get; set; }

        public List<HuffmanNode> AllNodes { get; set; } = new List<HuffmanNode>();
        public List<Link<HuffmanNode>> Links { get; set; } = new List<Link<HuffmanNode>>();
        public void CreateNode(HuffmanNode no)
        {
            AllNodes.Add(no);
        }
        public void CreateLink(HuffmanNode parent, HuffmanNode child, int weight)
        {
            Links.Add(new Link<HuffmanNode>() { Parent = parent, Child = child, Weight = weight });
        }
    }

}
