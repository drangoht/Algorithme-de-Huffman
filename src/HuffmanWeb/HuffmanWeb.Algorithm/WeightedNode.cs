using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class WeightedNode<T>
    {
        public T N { get; set; }

        public WeightedNode(T no)
        {
            N = no;
        }
    }
}
