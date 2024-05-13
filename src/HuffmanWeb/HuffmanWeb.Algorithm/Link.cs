using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class Link<T>
    {
        public int Weight { get; set; }
        public T Parent { get; set; }
        public T Child { get; set; }
    }
}
