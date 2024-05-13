using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HuffmanWeb.Algorithm
{
    public class WeightedGraph
    {
        public HuffmanNode? Root { get; set; }

        public List<HuffmanNode> AllNodes = new List<HuffmanNode>();
        public List<Link<HuffmanNode>> Links = new List<Link<HuffmanNode>>();
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
            List<int> weights = new List<int>();
            Stack<HuffmanNodeWeighted> stack = new Stack<HuffmanNodeWeighted>();
            stack.Push(new HuffmanNodeWeighted() { Node = root, Weight = null });
            Hashtable huffmanTable = new Hashtable();
            // LIFO
            while (stack.Count>0)
            {
                var n = stack.Pop();
                if (n.Node.Character != Char.MinValue)
                    huffmanTable.Add(n.Node.Character, n.Weight);

                var links = Links.Where(l => l.Parent == n.Node).ToList();
                if (links.Count()>0)
                {
                    foreach( var link in links)
                        stack.Push((new() { Node = link.Child, Weight = $"{n.Weight}{link.Weight}" }));
                    
                }
            }
            return huffmanTable;
        }
        
    }

}
