using System.Collections.Generic;
using System.IO;
using COTL_API.CustomInventory;
using static CookingData;

namespace FoodPlus.Items.Food.Meals;
[MealToRegister]
internal class CamillaSalad : CustomMeal
{
    public override string InternalName => "Camilla_Salad";
    public override float TummyRating => 1f;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Camilla Salad";
    public override string LocalizedLore() => "Med-bay in a bowl";
    public override string LocalizedDescription() => "A dish of flowers to heal your followers";
    public override Sprite Sprite => CreateSprite(MealsPath, "Camilla_Salad.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 75;
    public override MealQuality Quality => MealQuality.GOOD;
    public override int SatiationLevel => 3;

    public override MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = MealEffectType.HealsIllness,
            Chance = 100
        },
        new()
        {
            MealEffectType = MealEffectType.InstantlyVomit,
            Chance = 100
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(InventoryItem.ITEM_TYPE.FLOWER_RED, 5),
            new InventoryItem(InventoryItem.ITEM_TYPE.GRAPES, 3),
            new InventoryItem(InventoryItem.ITEM_TYPE.GRASS, 3),
        ]
    ];
}