using System;
using System.Collections;
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
        public Hashtable DFS(HuffmanNode root)
        {
            List<int> weights = new List<int>();
            string code = string.Empty;
            Stack<HuffmanNode> stack = new Stack<HuffmanNode>();
            stack.Push(root);
            var parent = root;
            Hashtable huffmanTable = new Hashtable();
            // LIFO
            while (stack.Count>0)
            {

                var n = stack.Pop();
                if (parent != n)
                {
                    if (IsLinkExist(parent, n)) // ajout du poids du lien parent avec le noeud courant
                        weights.Add(GetWeightFromLink(parent, n));
                    else
                    {
                        // Backtracking
                        weights.RemoveAt(weights.Count - 1);
                        parent = GetParent(parent);
                        if (IsLinkExist(parent, n)) // ajout du poids du lien grand parent avec le noeud courant
                            weights.Add(GetWeightFromLink(parent, n));
                    }
                }
                
                if (n.Character != Char.MinValue)
                {
                    // On est sur une feuille on écrit le caractère et les  poids concaténés
                    huffmanTable.Add(n.Character, String.Join("", weights));
                    // suppression du poids de ce lien
                    weights.RemoveAt(weights.Count - 1);
                }
                else // On garde le parent pour retrouver le poid du lien
                    parent = n;

                if (HasChild(n))
                {
                    foreach (var node in GetChildrenNodes(n))
                        stack.Push(node);
                }
                

            }
            return huffmanTable;
        }
        private int GetWeightFromLink(HuffmanNode parent, HuffmanNode child) =>
            Links.FirstOrDefault(l => l.Parent == parent && l.Child == child)!.Weight;

        private List<HuffmanNode> GetChildrenNodes(HuffmanNode parent)
        {
            var childrenLink = Links.Where(l => l.Parent ==parent).OrderBy(l => l.Weight).ToList();
            return childrenLink.Select(cl => cl.Child).ToList();
        }
        private HuffmanNode GetParent(HuffmanNode child)
        {
            return Links.FirstOrDefault(l => l.Child == child)!.Parent;
        }
        private bool HasChild(HuffmanNode parent) =>
            Links.Any(l => l.Parent == parent);
        private bool IsLinkExist(HuffmanNode parent, HuffmanNode child) =>
            Links.Any(l => l.Parent == parent && l.Child == child);
        
    }

}
