using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class HuffmanNodeWeighted
    {
        public HuffmanNode Node { get; set; } = new(char.MinValue,0);
        public string? Weight { get; set; } = string.Empty;
    }
}
