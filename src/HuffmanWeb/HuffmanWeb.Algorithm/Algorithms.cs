using HuffmanWeb.Common.DTOs;

namespace HuffmanWeb.Algorithm
{
    public static class Algorithms
    {
        public static Dictionary<char, string> DFS(HuffmanNode root, List<Link<HuffmanNode>> graphlinks)
        {
            var stack = new Stack<HuffmanNodeWeighted>();
            stack.Push(new HuffmanNodeWeighted() { Node = root, Weight = null });
            var huffmanTable = new Dictionary<char, string>();
            while (stack.Count > 0)
            {
                var n = stack.Pop();
                if (n.Node.Character != char.MinValue)
                    huffmanTable[n.Node.Character] = n.Weight ?? string.Empty;

                var links = graphlinks.Where(l => l.Parent == n.Node).ToList();
                foreach (var link in links)
                    stack.Push(new() { Node = link.Child!, Weight = $"{n.Weight}{link.Weight}" });
            }
            return huffmanTable;
        }
    }
}
