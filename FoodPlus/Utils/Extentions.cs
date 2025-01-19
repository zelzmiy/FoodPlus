using System.Collections.Generic;

namespace FoodPlus.Utils;

public static class Extensions
{
    public static void AddOrCreate<TKey, TValue>(this Dictionary<TKey, List<TValue>> dict, TKey key, TValue value)
    {
        if (dict.TryGetValue(key, out var list))
        {
            list.Add(value);
        }
        else
        {
            dict.Add(key, [value]);
        }
    }
}