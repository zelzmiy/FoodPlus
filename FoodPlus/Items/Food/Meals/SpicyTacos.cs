using System;
using System.Collections.Generic;
using System.Linq;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food.Meals;

public class SpicyTacos : CustomMeal
{
    public override string InternalName => "Spicy_Tacos";
    public override float TummyRating => 0.66f;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Spicy Tacos";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A meal for spice-lovers";
    public override Sprite Sprite => CreateSprite(MealsPath, "Spicy_Tacos.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 40;
    public override MealQuality Quality => MealQuality.NORMAL;
    public override int SatiationLevel => 2;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            // TODO replace this with a working version, this one does nothing :3
            MealEffectType = CookingData.MealEffectType.CausesWorkAllNight,
            Chance = 40,
        },
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(GainSinHalf)),
            Chance = 40,
        },
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(InjureMouthEffect)),
            Chance = 60,
        },
    ];

    public override List<List<InventoryItem>> Recipe => GetRecipe();

    // worst code ever!!!!!!!!
    private static List<List<InventoryItem>> GetRecipe()
    {
        try
        {
            var duplicate = Plugin.TacoRecipeOptions.ToList();
            duplicate.Remove(Plugin.FirstPriorityTacoRecipe.Value);
            return
            [
                GetIngredients(Plugin.FirstPriorityTacoRecipe.Value),
                GetIngredients(duplicate[0])
            ];
        }
        catch (NullReferenceException)
        {
            return
            [
                s_meatMorselRecipe,
                s_meatRecipe,
            ];
        }
    }

    private static List<InventoryItem> GetIngredients(string s)
    {
        return (s) switch
        {
            "Meat Morsel" => s_meatMorselRecipe,
            "Meat" => s_meatRecipe,
            _ => throw new ArgumentException("Invalid Ingredient Name"),
        };
    }

    private static readonly List<InventoryItem> s_meatMorselRecipe =
    [
        new(ItemRegistry.Get(nameof(Wheat)), 12),
        new(ItemRegistry.Get(nameof(Tomato)), 2),
        new(ItemRegistry.Get(nameof(DeathPepper)), 1),
        new(InventoryItem.ITEM_TYPE.MEAT_MORSEL, 4),
    ];

    private static readonly List<InventoryItem> s_meatRecipe =
    [
        new(ItemRegistry.Get(nameof(Wheat)), 12),
        new(ItemRegistry.Get(nameof(Tomato)), 2),
        new(ItemRegistry.Get(nameof(DeathPepper)), 1),
        new(InventoryItem.ITEM_TYPE.MEAT, 2),
    ];
}