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
        public long inputBinarySize { get; set; } = 0;
        public long intputHuffmanBinarySize { get; set; } = 0;
        public Graph<HuffmanNode> GeneratedGraph { get; set; } = new();

        public Huffman(string textToEncode)
        {
            _textToEncode = textToEncode;
            // Stockage de la taille binaire de l'entrée
            inputBinarySize = Encoding.Unicode.GetByteCount(textToEncode)*8;
        }
        
        // Extraction du nombre d'occurence des caractères dans l'entrée
        // En un tableau Car:NbOccurence

        // Fabrication du graph selon Huffman
        // Table de correspondance des caractères en binaire en se basant sur le graph
        // Encodage de l'entrée en utilisant la table de correspondance
        // Stockage de la taille encodée
        // Conversion du graph en binaire pour stockage
        // stockage de la taille binaire du graph

        void MakeGraph()
        {
            //List<HuffmanNode> nodes = _textToEncode.GroupBy(count,c )
            //var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
            //    Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
            //    Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
            //    Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            //var graph = new Graph<int>(vertices, edges);
        }

    }
    public record HuffmanNode(long nbOccurence, char character);
}
