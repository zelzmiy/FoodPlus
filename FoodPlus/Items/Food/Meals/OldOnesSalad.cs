using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.CustomTraits;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food.Meals;

public class OldOnesSalad : CustomMeal
{
    public override string InternalName => "Old_Ones_Salad";
    public override float TummyRating => 1f;
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Old One's Salad";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A dish worthy of the old ones";
    public override Sprite Sprite => CreateSprite(MealsPath, "Old_Ones_Salad.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 70;
    public override MealQuality Quality => MealQuality.GOOD;
    public override int SatiationLevel => 3;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = CookingData.MealEffectType.OldFollowerYoung,
            Chance = 60,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.IncreasesLoyalty,
            Chance = 60,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.HealsIllness,
            Chance = 40,
        },
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(ShuffleColorsEffect)),
            Chance = 80,
        }
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 2),
            new InventoryItem(ItemRegistry.Get(nameof(Onion)), 1),
            new InventoryItem(ItemRegistry.Get(nameof(DeathPepper)), 1),
            new InventoryItem(InventoryItem.ITEM_TYPE.BEETROOT, 1),
        ]
    ];
}