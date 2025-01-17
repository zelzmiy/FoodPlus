using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food;

public class GrassRoll : CustomMeal
{
    public override string InternalName => "Grass_Roll";
    public override float TummyRating => 0.33f;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Grass Roll";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A fishy meal";
    public override Sprite Sprite => CreateSprite(MealsPath, "Grass_Roll.png");
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
            Chance = 20,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.RemovesDissent,
            Chance = 25,
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(InventoryItem.ITEM_TYPE.FISH, 2),
            new InventoryItem(InventoryItem.ITEM_TYPE.GRASS, 1),
        ]
    ];
}