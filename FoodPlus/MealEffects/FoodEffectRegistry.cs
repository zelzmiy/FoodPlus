using System.Collections.Generic;
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
        s_items.Add(nameof(GainPettableTraitEffect), CustomFoodEffectManager.Add(new GainPettableTraitEffect()));
        s_items.Add(nameof(FallInLoveEffect), CustomFoodEffectManager.Add(new FallInLoveEffect()));
        s_items.Add(nameof(RemoveSpyEffect), CustomFoodEffectManager.Add(new RemoveSpyEffect()));
        s_items.Add(nameof(InjureMouth), CustomFoodEffectManager.Add(new InjureMouth()));
        s_items.Add(nameof(GainSinHalf), CustomFoodEffectManager.Add(new GainSinHalf()));
        s_items.Add(nameof(GainSinFull), CustomFoodEffectManager.Add(new GainSinFull()));
    }
}