using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class Huffman
    {
        string _textToEncode = string.Empty;
        public long InputBinarySize { get; set; } = 0;
        public long IntputHuffmanBinarySize { get; set; } = 0;
        public WeightedGraph GeneratedGraph { get; set; } = new();

        public Huffman(string textToEncode)
        {
            _textToEncode = textToEncode;
            // Stockage de la taille binaire de l'entrée
            InputBinarySize = Encoding.Unicode.GetByteCount(textToEncode)*8;
        }
        
        // Extraction du nombre d'occurence des caractères dans l'entrée
        // En un tableau Car:NbOccurence

        // Fabrication du graph selon Huffman
        // Table de correspondance des caractères en binaire en se basant sur le graph
        // Encodage de l'entrée en utilisant la table de correspondance
        // Stockage de la taille encodée
        // Conversion du graph en binaire pour stockage
        // stockage de la taille binaire du graph

        public void MakeGraph()
        {
            // Extraction du nombre d'occurence des caractères dans l'entrée
            List<HuffmanNode> nodes = _textToEncode.GroupBy((c) => c).Select((p) => new HuffmanNode ( p.Key, p.Count())).ToList();
            List<Tuple<HuffmanNode, HuffmanNode, int>> edges = new();
            List<HuffmanNode> vertices = new();
            HuffmanNode root = new(Char.MinValue, 0 );
            
            while (nodes.Count > 1)
            {
                // Récupération des 2 plus petits nombre d'occurence
                List<HuffmanNode> twoSmallestNodes = nodes.OrderBy(n => n.NbOccurence).Select(n => n).Take(2).ToList();
                root = new HuffmanNode(Char.MinValue, twoSmallestNodes.Sum(n => n.NbOccurence));
                GeneratedGraph.CreateNode(root);

                if (twoSmallestNodes[0].NbOccurence > 0)
                {
                    GeneratedGraph.CreateNode(twoSmallestNodes[0]);
                    GeneratedGraph.CreateLink(root, twoSmallestNodes[0], 0);
                }
                if (twoSmallestNodes[1].NbOccurence >0)
                {
                    GeneratedGraph.CreateNode(twoSmallestNodes[1]);
                    GeneratedGraph.CreateLink(root, twoSmallestNodes[1], 1);
                }
                // Suppression des noeuds gérés et ajout du parent
                nodes.Remove(twoSmallestNodes[0]);
                nodes.Remove(twoSmallestNodes[1]);
                nodes.Add(root);
                
            }
            Console.WriteLine(GeneratedGraph.DFS(root));

            //var hash = GeneratedGraph.BFS(GeneratedGraph, root);
           //Console.WriteLine("FIN");
        }


    }
    public record HuffmanNode(char Character, long NbOccurence);
}
