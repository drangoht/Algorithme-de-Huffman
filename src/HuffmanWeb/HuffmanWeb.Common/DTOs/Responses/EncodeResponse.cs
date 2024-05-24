
namespace HuffmanWeb.Common.DTOs.Responses
{
    public class EncodeResponse
    {
        public WeightedGraph Graph { get; set; } = new();
        public List<Character> MatchingCharacters { get; set; } = new();
        public long EncodedSize { get; set; } = 0;
        public long OriginalSize { get; set; } = 0;
        public string EncodedBinaryString { get; set; } = string.Empty;

    }
}
