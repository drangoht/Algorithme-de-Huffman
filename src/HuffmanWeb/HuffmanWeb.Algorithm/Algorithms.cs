using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public static class Algorithms
    {
        public static Hashtable DFS(HuffmanNode root, List<Link<HuffmanNode>> graphlinks)
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

                var links = graphlinks.Where(l => l.Parent == n.Node).ToList();
                foreach (var link in links)
                    stack.Push((new() { Node = link.Child, Weight = $"{n.Weight}{link.Weight}" }));

            }
            return huffmanTable;
        }
    }
}
