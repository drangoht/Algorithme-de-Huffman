﻿namespace HuffmanWeb.Algorithm
{
    public class Link<T>
    {
        public int Weight { get; set; }
        public T? Parent { get; set; }
        public T? Child { get; set; }
    }
}
