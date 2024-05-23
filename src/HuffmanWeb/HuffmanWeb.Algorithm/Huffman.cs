using System.Collections;
using System.Text;

namespace HuffmanWeb.Algorithm
{
    public static class Huffman
    {

        // Extraction du nombre d'occurence des caractères dans l'entrée
        // En un tableau Car:NbOccurence

        // Fabrication du graph selon Huffman
        // Table de correspondance des caractères en binaire en se basant sur le graph
        // Encodage de l'entrée en utilisant la table de correspondance
        // Stockage de la taille encodée
        // Conversion du graph en binaire pour stockage
        // stockage de la taille binaire du graph

        public static Hashtable MakeMatchingTable(string textToEncode)
        {
            // Extraction du nombre d'occurence des caractères dans l'entrée
            List<HuffmanNode> nodes = GetNodesFromString(textToEncode);
            var generatedGraph = GenerateHuffmanGraph(nodes);
            return Algorithms.DFS(generatedGraph.Root,generatedGraph.Links);

        }
        
        public static List<HuffmanNode> GetNodesFromString(string textToEncode) =>
            textToEncode.GroupBy((c) => c).Select((p) => new HuffmanNode(p.Key, p.Count())).ToList();

        public static WeightedGraph GenerateHuffmanGraph(List<HuffmanNode> nodes)
        {
            WeightedGraph graph = new WeightedGraph();
            HuffmanNode root = new(Char.MinValue, 0);
            while (nodes.Count() > 1)
            {
                // Récupération des 2 plus petits nombre d'occurence
                List<HuffmanNode> twoSmallestNodes = nodes.OrderBy(n => n.NbOccurence).Select(n => n).Take(2).ToList();
                root = new HuffmanNode(Char.MinValue, twoSmallestNodes.Sum(n => n.NbOccurence));
                graph.CreateNode(root);

                var weight = 0;
                if (twoSmallestNodes.Count() > 0)
                {
                    graph.CreateNode(twoSmallestNodes[0]);
                    graph.CreateLink(root, twoSmallestNodes[0], weight);
                    nodes.Remove(twoSmallestNodes[0]);
                    weight = 1;
                }
                if (twoSmallestNodes.Count() > 1)
                {
                    graph.CreateNode(twoSmallestNodes[1]);
                    graph.CreateLink(root, twoSmallestNodes[1], weight);
                    nodes.Remove(twoSmallestNodes[1]);
                }
                nodes.Add(root);

            }
            graph.Root = root;
            return graph;
        }

        public static int GetBinarySize(string textToEncode)
        {
            return Encoding.Unicode.GetByteCount(textToEncode) * 8;
        }

        public static string EncodeText(string textToEncode)
        {
            string textEncoded = string.Empty;
            var huffmanTable = MakeMatchingTable(textToEncode);
            foreach (var c in textToEncode)
            {
                if (huffmanTable.ContainsKey(c))
                {
                    textEncoded += huffmanTable[c];
                }
            }
            return textEncoded;
        }

        public static string DecodeText(string textToDecode, Hashtable matchingCharactersTable)
        {
            
            string textDecoded = string.Empty;
            string search = string.Empty;
            foreach (var c in textToDecode)
            {
                search += c;
                foreach (var key in matchingCharactersTable.Keys)
                {
                    if (matchingCharactersTable[key].ToString() == search)
                    {
                        search = string.Empty;
                        textDecoded += key;
                        break;
                    }
                }
            }
            return textDecoded;
        }

    }

}

