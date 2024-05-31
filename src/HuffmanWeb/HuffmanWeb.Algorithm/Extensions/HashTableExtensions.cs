using System.Collections;

namespace HuffmanWeb.Algorithm.Extensions
{
    public static class HashTableExtensions
    {
        public static string? GetKeyByValue(this Hashtable table, string value) =>
            table.Keys.OfType<string>().FirstOrDefault(s => table[s]!.ToString() == value);

    }
}
