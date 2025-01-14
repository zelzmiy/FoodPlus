using System.Collections.Generic;
using FoodPlus.CustomTraits.Traits;

namespace FoodPlus.CustomTraits;

public static class TraitRegistry
{
    private static readonly Dictionary<string, FollowerTrait.TraitType> s_items = [];

    public static FollowerTrait.TraitType Get(string itemName) 
    {
        return s_items[itemName];
    }

    public static void RegisterTraits()
    {
        s_items.Add(nameof(NeonPooperTrait), CustomTraitManager.Add(new NeonPooperTrait()));
    }
}