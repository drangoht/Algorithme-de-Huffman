using System.Collections;

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
        public Hashtable DFS(HuffmanNode root)
        {
            Stack<HuffmanNodeWeighted> stack = new Stack<HuffmanNodeWeighted>();
            stack.Push(new HuffmanNodeWeighted() { Node = root, Weight = null });
            Hashtable huffmanTable = new Hashtable();
            // LIFO
            while (stack.Count > 0)
            {
                var n = stack.Pop();
                if (n.Node.Character != Char.MinValue)
                    huffmanTable.Add(n.Node.Character, n.Weight);

                var links = Links.Where(l => l.Parent == n.Node).ToList();
                foreach (var link in links)
                    stack.Push((new() { Node = link.Child, Weight = $"{n.Weight}{link.Weight}" }));

            }
            return huffmanTable;
        }

    }

}
