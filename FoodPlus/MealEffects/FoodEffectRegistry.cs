using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects;

public static class FoodEffectRegistry
{
    private static readonly Dictionary<string, CookingData.MealEffectType> s_items = [];

    public static CookingData.MealEffectType Get(string itemName) 
    {
        return s_items[itemName];
    }

    public static void RegisterFoodEffects()
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttribute<FoodEffectToRegister>() != null)
            .Do((type) =>
            {
                s_items.Add(type.Name, CustomFoodEffectManager.Add((CustomFoodEffect)Activator.CreateInstance(type)));
            });
    }
    
}