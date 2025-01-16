using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food.Drinks;

// Todo: come up with a "friendly" way to say whiskey, kind of like how wine is called "grape nectar"
// wheat broth? gross... gluten hash? sounds... sticky
// durum drink? good enough for now
internal class Whiskey : CustomDrink
{
    public override string InternalName => "Whiskey";
    public override string LocalizedName() => "Durum Drink";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A strong drink";
    public override Sprite Sprite => CreateSprite(DrinksPath, "Whiskey.png");
    public override Sprite InventoryIcon => Sprite;
    public override int SatiationLevel => 2;
    public override int Pleasure => 45;
    
    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(RemoveSleepyEffect)),
            Chance = 50,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.CausesDrunk,
            Chance = 80,
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(Wheat)), 6),
        ]
    ];
}