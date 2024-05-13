using HuffmanWeb.Algorithm;

namespace HuffmanWeb.Server.DTOs
{
    public class TextToEncodeResponse
    {
        public WeightedGraph Graph { get; set; } = new();
        public List<Character> MatchingCharacters { get; set; } = new();
        public long EncodedSize { get; set; } = 0;
        public long OriginalSize { get; set; } = 0;
        public string EncodedBinaryString { get; set; } = string.Empty;

    }
    public class Character
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
