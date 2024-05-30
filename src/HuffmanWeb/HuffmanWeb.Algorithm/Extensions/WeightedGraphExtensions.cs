using HuffmanWeb.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm.Extensions
{
    public static class WeightedGraphExtensions
    {
        public static void ComputeDescendants(this WeightedGraph graph)
        {
            var leafLinks = graph.Links.Where(l => l.Child?.Character != char.MinValue).ToList();
            foreach(var link in leafLinks) 
            {
                var node = graph.AllNodes.FirstOrDefault(n => n == link.Parent);
                if(node != null)
                    node.DescendantsCount++;
            }
            List<HuffmanNode> visitedNodes = new();
            var links = graph.Links.Where(l => l.Child?.DescendantsCount > 0 && !visitedNodes.Any(n => n == l.Parent)).ToList();
            while (links.Count > 0)
            {
                
                foreach (var link in links)
                {
                    var node = graph.AllNodes.FirstOrDefault(n => n == link.Parent);
                    var child = link.Child;
                    if (node != null && child != null)
                    {
                        node.DescendantsCount += child.DescendantsCount;
                        visitedNodes.Add(node);
                    }
                }
                links = graph.Links.Where(l => l.Child?.DescendantsCount > 0 && !visitedNodes.Any(n => n == l.Parent)).ToList();
            } 
        }
    }
}
