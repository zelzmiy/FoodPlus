using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.MealEffects;
using FoodPlus.MealEffects.Effects;

namespace FoodPlus.Items.Food.Meals;
[MealToRegister]
public class DionysianSalad : CustomMeal
{
    public override string InternalName => "Dionysian_Salad";
    public override float TummyRating => 0.15f;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Dionysian Salad";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A meal filled with love";
    public override Sprite Sprite => CreateSprite(MealsPath, "Dionysian_Salad.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 0;
    public override MealQuality Quality => MealQuality.NORMAL;
    public override int SatiationLevel => 2;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(GainPolyTraitEffect)),
            Chance = 60,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.CausesDrunk,
            Chance = 40,
        }
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(InventoryItem.ITEM_TYPE.BERRY, 3),
            new InventoryItem(InventoryItem.ITEM_TYPE.GRAPES, 4),
            new InventoryItem(InventoryItem.ITEM_TYPE.MUSHROOM_SMALL, 12),
        ]
    ];
}