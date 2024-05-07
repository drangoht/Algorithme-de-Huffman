using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class Huffman
    {
        string _textToEncode = string.Empty;
        string _textToDecode = string.Empty;    
        public string TextEncoded { get; set; } = string.Empty;
        public string TextDecoded { get; set; } = string.Empty;
        public long InputBinarySize { get; set; } = 0;
        public long InputHuffmanBinarySize { get; set; } = 0;
        public WeightedGraph GeneratedGraph { get; set; } = new();

        public Hashtable HuffmanTable { get; set; } = new();
        public Huffman()
        {
            // Stockage de la taille binaire de l'entrée
            
        }
        
        // Extraction du nombre d'occurence des caractères dans l'entrée
        // En un tableau Car:NbOccurence

        // Fabrication du graph selon Huffman
        // Table de correspondance des caractères en binaire en se basant sur le graph
        // Encodage de l'entrée en utilisant la table de correspondance
        // Stockage de la taille encodée
        // Conversion du graph en binaire pour stockage
        // stockage de la taille binaire du graph

        private void MakeMatchingTable()
        {
            // Extraction du nombre d'occurence des caractères dans l'entrée
            List<HuffmanNode> nodes = _textToEncode.GroupBy((c) => c).Select((p) => new HuffmanNode ( p.Key, p.Count())).ToList();
            HuffmanNode root = new(Char.MinValue, 0 );
            
            while (nodes.Count > 1)
            {
                // Récupération des 2 plus petits nombre d'occurence
                List<HuffmanNode> twoSmallestNodes = nodes.OrderBy(n => n.NbOccurence).Select(n => n).Take(2).ToList();
                root = new HuffmanNode(Char.MinValue, twoSmallestNodes.Sum(n => n.NbOccurence));
                GeneratedGraph.CreateNode(root);

                var weight = 0;
                if (twoSmallestNodes[0].NbOccurence > 0)
                {
                    GeneratedGraph.CreateNode(twoSmallestNodes[0]);
                    GeneratedGraph.CreateLink(root, twoSmallestNodes[0], weight);
                    nodes.Remove(twoSmallestNodes[0]);
                    weight = 1;
                }
                if (twoSmallestNodes.Count()>1)
                {
                    GeneratedGraph.CreateNode(twoSmallestNodes[1]);
                    GeneratedGraph.CreateLink(root, twoSmallestNodes[1], weight);
                    nodes.Remove(twoSmallestNodes[1]);
                }                                
                nodes.Add(root);

            }
            GeneratedGraph.Root = root;
            HuffmanTable = GeneratedGraph.DFS(root);

        }
        private void StoreOriginalSize()
        {
            InputBinarySize = Encoding.Unicode.GetByteCount(_textToEncode) * 8;
        }
        public void EncodeText(string textToEncode)
        {
            _textToEncode = textToEncode;
            StoreOriginalSize();
            MakeMatchingTable();
            foreach( var c in _textToEncode )
            {
                if (HuffmanTable.ContainsKey(c))
                {
                    TextEncoded += HuffmanTable[c];
                }
            }
            InputHuffmanBinarySize = TextEncoded.Length;
        }
        // For testingPurpose
        public void EncodeAndDecodeText(string textToEncode)
        {
            _textToEncode = textToEncode;
            StoreOriginalSize();
            MakeMatchingTable();
            foreach (var c in _textToEncode)
            {
                if (HuffmanTable.ContainsKey(c))
                {
                    TextEncoded += HuffmanTable[c];
                }
            }
            InputHuffmanBinarySize = TextEncoded.Length;

            string search = string.Empty;
            foreach(var c in TextEncoded)
            {
                search += c;
                foreach( var key in HuffmanTable.Keys )
                {
                    if (HuffmanTable[key].ToString() == search)
                    {
                        search = string.Empty;
                        TextDecoded += key;
                        break;
                    }
                }
            }
        }

    }
        
}

