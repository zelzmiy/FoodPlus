using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoodPlus.CustomTraits.Traits;
using FoodPlus.Utils;

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
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttribute<TraitToRegister>() != null)
            .Do((type) =>
            {
                s_items.Add(type.Name, CustomTraitManager.Add((CustomTrait)Activator.CreateInstance(type)));
            });
    }
}