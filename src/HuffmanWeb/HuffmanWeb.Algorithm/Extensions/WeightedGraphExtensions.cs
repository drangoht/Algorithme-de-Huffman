using HuffmanWeb.Common.DTOs;

namespace HuffmanWeb.Algorithm.Extensions
{
    public static class WeightedGraphExtensions
    {
        public static void ComputeDescendants(this WeightedGraph graph)
        {
            var links = graph.Links.Where(l => l.Child?.Character != char.MinValue).ToList();
            foreach (var link in links)
            {
                var nodeParent = graph.AllNodes.FirstOrDefault(n => n == link.Parent);
                FillDescendantsCount(graph, nodeParent, link.Child);

            }
        }
        private static void FillDescendantsCount(WeightedGraph graph, HuffmanNode? parentNode, HuffmanNode? childNode)
        {
            if (parentNode == null) return;
            // Count direct descendantsNode + add sum of descendants node
            parentNode.DescendantsCount = graph.Links.Count(l => l.Parent == parentNode) + graph.Links.Where(l => l.Parent == parentNode).Sum(n => n.Child.DescendantsCount);
            FillDescendantsCount(graph, graph.Links.FirstOrDefault(n => n.Child == parentNode)?.Parent, parentNode);
        }
    }
}
