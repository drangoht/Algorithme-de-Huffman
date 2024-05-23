namespace HuffmanWeb.Server.DTOs
{
    public class DecodeRequest
    {
        public String BinaryHuffman { get; set; } = string.Empty;
        public List<Character> MatchingCharacters { get; set; } = new();
    }
}
