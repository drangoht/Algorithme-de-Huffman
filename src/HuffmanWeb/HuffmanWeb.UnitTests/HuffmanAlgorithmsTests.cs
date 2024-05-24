using FluentAssertions;

namespace HuffmanWeb.UnitTests
{
    public class HuffmanAlgorithmsTests
    {
        [Theory]
        [InlineData("a",16)]
        [InlineData("It works", 128)]
        public void ShouldReturnBinarySizeWhenTextIsProvided(string text,int size)
        {
            var attendedSize = HuffmanWeb.Algorithm.Huffman.GetBinarySize(text);
            
            size.Should().Be(attendedSize);
        }
    }
}