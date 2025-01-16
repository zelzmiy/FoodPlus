using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;

namespace FoodPlus.Items.Food.Drinks;

internal class TomatoJuice : CustomDrink
{
    public override string InternalName => "Tomato_Juice";
    public override string LocalizedName() => "Tomato Juice";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A Savory Drink";
    public override Sprite Sprite => CreateSprite(DrinksPath, "Tomato_Juice.png");
    public override Sprite InventoryIcon => Sprite;
    public override int SatiationLevel => 1;    
    public override int Pleasure => 0;
    
    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = CookingData.MealEffectType.DropLoot,
            Chance = 25,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.CausesIllness,
            Chance = 15,
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 5),
        ]
    ];
}