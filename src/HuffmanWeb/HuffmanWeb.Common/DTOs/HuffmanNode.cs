namespace HuffmanWeb.Common.DTOs
{
    public sealed class HuffmanNode : IEquatable<HuffmanNode>
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
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Identifier.Equals(other.Identifier);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HuffmanNode);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id:{Identifier} Character:{Character} NbOccurence :{NbOccurence}";
        }
    }

}

