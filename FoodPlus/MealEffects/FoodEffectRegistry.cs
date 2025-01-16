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
        s_items.Add(nameof(GainRoyalPooperTraitEffect), CustomFoodEffectManager.Add(new GainRoyalPooperTraitEffect()));
        s_items.Add(nameof(GainNeonPooperTraitEffect), CustomFoodEffectManager.Add(new GainNeonPooperTraitEffect()));
        s_items.Add(nameof(GainPettableTraitEffect), CustomFoodEffectManager.Add(new GainPettableTraitEffect()));
        s_items.Add(nameof(RemoveTerrifiedEffect), CustomFoodEffectManager.Add(new RemoveTerrifiedEffect()));
        s_items.Add(nameof(GainPolyTraitEffect), CustomFoodEffectManager.Add(new GainPolyTraitEffect()));
        s_items.Add(nameof(ShuffleColorsEffect), CustomFoodEffectManager.Add(new ShuffleColorsEffect()));
        s_items.Add(nameof(RemoveSleepyEffect), CustomFoodEffectManager.Add(new RemoveSleepyEffect()));
        s_items.Add(nameof(InjureMouthEffect), CustomFoodEffectManager.Add(new InjureMouthEffect()));
        s_items.Add(nameof(FallInLoveEffect), CustomFoodEffectManager.Add(new FallInLoveEffect()));
        s_items.Add(nameof(RemoveSpyEffect), CustomFoodEffectManager.Add(new RemoveSpyEffect()));
        s_items.Add(nameof(GainSinHalf), CustomFoodEffectManager.Add(new GainSinHalf()));
        s_items.Add(nameof(GainSinFull), CustomFoodEffectManager.Add(new GainSinFull()));
    }
}