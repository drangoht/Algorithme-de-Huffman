using HuffmanWeb.Algorithm.Extensions;
using HuffmanWeb.Common.DTOs;
using System.Text;

namespace HuffmanWeb.Algorithm
{
    public static class Huffman
    {
        public static Dictionary<char, string> MakeMatchingTable(string textToEncode)
        {
            var nodes = GetNodesFromString(textToEncode);
            var graph = GenerateHuffmanGraph(nodes);
            return MakeMatchingTable(graph);
        }

        public static Dictionary<char, string> MakeMatchingTable(WeightedGraph graph)
        {
            return Algorithms.DFS(graph.Root!, graph.Links);
        }

        public static List<HuffmanNode> GetNodesFromString(string textToEncode) =>
            textToEncode.GroupBy(c => c).Select(p => new HuffmanNode(p.Key, p.Count())).ToList();

        public static WeightedGraph GenerateHuffmanGraph(List<HuffmanNode> nodes)
        {
            var graph = new WeightedGraph();
            var root = new HuffmanNode(char.MinValue, 0);
            while (nodes.Count > 0)
            {
                var twoSmallest = nodes.OrderBy(n => n.NbOccurence).Take(2).ToList();
                root = new HuffmanNode(char.MinValue, twoSmallest.Sum(n => n.NbOccurence));
                graph.CreateNode(root);

                var weight = 0;
                if (twoSmallest.Count > 0)
                {
                    graph.CreateNode(twoSmallest[0]);
                    graph.CreateLink(root, twoSmallest[0], weight);
                    nodes.Remove(twoSmallest[0]);
                    weight = 1;
                }
                if (twoSmallest.Count > 1)
                {
                    graph.CreateNode(twoSmallest[1]);
                    graph.CreateLink(root, twoSmallest[1], weight);
                    nodes.Remove(twoSmallest[1]);
                }
                if (nodes.Count > 0)
                    nodes.Add(root);
            }
            graph.Root = root;
            return graph;
        }

        public static int GetBinarySize(string textToEncode) =>
            Encoding.Unicode.GetByteCount(textToEncode) * 8;

        public static string EncodeText(string textToEncode)
        {
            var table = MakeMatchingTable(textToEncode);
            return EncodeText(textToEncode, table);
        }

        public static string EncodeText(string textToEncode, Dictionary<char, string> table)
        {
            var sb = new StringBuilder();
            foreach (var c in textToEncode)
            {
                if (table.TryGetValue(c, out var code))
                    sb.Append(code);
            }
            return sb.ToString();
        }

        public static string DecodeText(string textToDecode, Dictionary<char, string> matchingTable)
        {
            var invertedTable = matchingTable.ToDictionary(kv => kv.Value, kv => kv.Key);
            var textDecoded = new StringBuilder();
            var search = new StringBuilder();
            foreach (var c in textToDecode)
            {
                search.Append(c);
                if (invertedTable.TryGetValue(search.ToString(), out var character))
                {
                    search.Clear();
                    textDecoded.Append(character);
                }
            }
            return textDecoded.ToString();
        }
    }
}
