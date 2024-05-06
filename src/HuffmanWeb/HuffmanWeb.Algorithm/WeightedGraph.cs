using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class WeightedGraph
    {
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
        public string DFS(HuffmanNode root)
        {
            string result = string.Empty;
            string code = string.Empty;
            Queue<HuffmanNode> queue = new Queue<HuffmanNode>();
            queue.Enqueue(root);
            // Empiler racine
            while (queue.Count>0)
            {
                var n = queue.Dequeue();
                Console.WriteLine(n);
                var child = Links.FirstOrDefault(l => l.Child!.Equals(n));
                if (child != null)
                {
                    Console.WriteLine($"{child.Weight}");
                    result += $"{child.Weight}";
                }

                if(Links.Any(l => l.Parent!.Equals(n)))
                {
                    var childrenLink = Links.Where(l => l.Parent!.Equals(n)).Reverse().ToList();
                    foreach (var link in childrenLink)
                    {
                        queue.Enqueue(link.Child);
                    }
                }
                else
                    result += $"{n.Character};";

            }
            return result;
        }
    }

}
