using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Algorithm.Extensions
{
    public static class HashTableExtensions
    {
        public static string? GetKeyByValue(this Hashtable table, string value) =>
            table.Keys.OfType<string>().FirstOrDefault(s => table[s]!.ToString() == value);

    }
}
