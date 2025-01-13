using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food;

public class Burger : CustomMeal
{
    public override string InternalName => "Burger";
    public override float TummyRating => 1f;
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Burger";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A complex dish";
    public override Sprite Sprite => CreateSprite(MealsPath, "Burger.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 85;
    public override MealQuality Quality => MealQuality.GOOD;
    public override int SatiationLevel => 3;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = CookingData.MealEffectType.DropLoot,
            Chance = 100,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.RemovesDissent,
            Chance = 100,
        },
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(GainPettableTraitEffect)),
            Chance = 100
        }
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(InventoryItem.ITEM_TYPE.MEAT, 2),
            new InventoryItem(ItemRegistry.Get(nameof(Bread)), 2),
            new InventoryItem(InventoryItem.ITEM_TYPE.GRASS, 2),
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 1),
            new InventoryItem(ItemRegistry.Get(nameof(Onion)), 1),
        ]
    ];
}