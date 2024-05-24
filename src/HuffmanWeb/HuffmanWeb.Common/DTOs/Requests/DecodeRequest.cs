namespace HuffmanWeb.Common.DTOs.Requests
{
    public class DecodeRequest
    {
        public string BinaryHuffman { get; set; } = string.Empty;
        public List<Character> MatchingCharacters { get; set; } = new();
    }
}
