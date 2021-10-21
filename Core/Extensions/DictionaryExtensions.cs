using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static byte AddOrUpdate<T, V>(this Dictionary<T, V> dict, T key, V newValue)
        {
            V oldValue;
            if (dict.TryGetValue(key,out oldValue))
            {
                dict[key] = newValue;
                return 1;
            }
            else
            {
                dict.Add(key, newValue);
                return 0;
            }
        }
    }
}
