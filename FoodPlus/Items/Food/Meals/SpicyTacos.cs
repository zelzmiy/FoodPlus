using System.Collections.Generic;
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

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(Wheat)), 12),
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 2),
            new InventoryItem(ItemRegistry.Get(nameof(DeathPepper)), 1),
            new InventoryItem(InventoryItem.ITEM_TYPE.MEAT_MORSEL, 4),
        ],
        [
            new InventoryItem(ItemRegistry.Get(nameof(Wheat)), 12),
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 2),
            new InventoryItem(ItemRegistry.Get(nameof(DeathPepper)), 1),
            new InventoryItem(InventoryItem.ITEM_TYPE.MEAT, 2),
        ],
        [
            new InventoryItem(ItemRegistry.Get(nameof(Wheat)), 12),
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 2),
            new InventoryItem(ItemRegistry.Get(nameof(DeathPepper)), 1),
            new InventoryItem(InventoryItem.ITEM_TYPE.FOLLOWER_MEAT, 1),
        ]
    ];
}