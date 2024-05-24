using FluentAssertions;
using HuffmanWeb.Algorithm;
namespace HuffmanWeb.UnitTests
{
    public class HuffmanAlgorithmsTests
    {
        [Theory]
        [InlineData("a",16)]
        [InlineData("It works", 128)]
        public void ShouldReturnBinarySizeWhenTextIsProvided(string text,int size)
        {
            var attendedSize = Huffman.GetBinarySize(text);
            
            size.Should().Be(attendedSize);
        }

        [Theory]
        [InlineData("aabb",2)]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 26)]
        public void ShouldReturnCorrectMatchingTableCountWhenTextIsProvided(string text,int count)
        {
            var matchingTable = Huffman.MakeMatchingTable(text);

            var attendedCount = matchingTable.Count;

            count.Should().Be(attendedCount);
        }

        [Theory]
        [InlineData("aabb", 2)]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 26)]
        public void ShouldReturnCorrectNodesCountWhenTextIsProvided(string text, int count)
        {
            var nodes = Huffman.GetNodesFromString(text);

            var attendedCount = nodes.Count;

            count.Should().Be(attendedCount);
        }


    }
}