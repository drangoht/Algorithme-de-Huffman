namespace HuffmanWeb.Server.DTOs
{
    public class TextToEncodeResponse
    {
        public List<Tuple<string, string>> MatchingCharacters { get; set; } = new();
        public long encodedSize { get; set; } = 0;
        public long originalSize { get; set; } = 0;
        public string encodedBinaryString { get; set; } = string.Empty;

    }
}
