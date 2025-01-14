using System.Collections.Generic;
using FoodPlus.CustomTraits;
using FoodPlus.CustomTraits.Traits;
using FoodPlus.Items;
using FoodPlus.Items.Food.Meals;
using src.UI.InfoCards;

namespace FoodPlus.Patches;

[HarmonyPatch]
public static class SpicyPatches
{
    private static List<InventoryItem.ITEM_TYPE> SpicyMeals =>
    [
        ItemRegistry.Get(nameof(SpicyTacos)),
        ItemRegistry.Get(nameof(HatefulDish)),
        ItemRegistry.Get(nameof(SpicyTunaSalad)),
    ];

    [HarmonyPatch(typeof(CookingData), nameof(CookingData.DoMealEffect))]
    [HarmonyPostfix]
    private static void CookingData_DoMealEffect(InventoryItem.ITEM_TYPE meal, FollowerBrain follower)
    {
        if (!SpicyMeals.Contains(meal)) return;

        if (follower.HasTrait(TraitRegistry.Get(nameof(SpiceLoverTrait))))
        {
            CultFaithManager.GetFaith(
                15f,
                0.5f, // ? 
                true,
                NotificationBase.Flair.Positive,
                $"{follower.Info.Name} ate a spicy dish!");
            return;
        }
        if (follower.HasTrait(TraitRegistry.Get(nameof(SpiceLoverTrait))))
        {
            CultFaithManager.GetFaith(
                -15f,
                0.5f, // ? 
                true,
                NotificationBase.Flair.Negative,
                $"{follower.Info.Name} ate a spicy dish.");
        }
    }
}