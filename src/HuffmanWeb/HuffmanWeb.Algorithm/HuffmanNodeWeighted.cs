namespace HuffmanWeb.Algorithm
{
    public class HuffmanNodeWeighted
    {
        public HuffmanNode Node { get; set; } = new(char.MinValue, 0);
        public string? Weight { get; set; } = string.Empty;
    }
}
