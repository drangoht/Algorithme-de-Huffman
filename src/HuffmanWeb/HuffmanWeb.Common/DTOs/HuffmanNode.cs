namespace HuffmanWeb.Common.DTOs
{
    public class HuffmanNode : IEquatable<HuffmanNode>
    {
        public Guid Identifier { get; set; } = Guid.NewGuid();
        public char Character { get; set; }
        public long NbOccurence { get; set; }
        public int DescendantsCount { get; set; } = 0;

        public HuffmanNode(Char character, long nbOccurence)
        {
            Character = character;
            NbOccurence = nbOccurence;
        }
        public bool Equals(HuffmanNode? other)
        {
            return other?.Identifier == this.Identifier;
        }
        public override string ToString()
        {
            return $"Id:{Identifier} Character:{Character} NbOccurence :{NbOccurence}";
        }
    }

}

