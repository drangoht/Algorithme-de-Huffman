﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm
{
    public class Link<T>
    {
        public int Weight;
        public T Parent;
        public T Child;
    }
}