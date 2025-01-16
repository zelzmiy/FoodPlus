using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food.Meals;

public class SpicyTunaSalad : CustomMeal
{
    public override string InternalName => "Spicy_Tuna_Salad";
    public override float TummyRating => 0.66f;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Spicy Tuna Salad";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => "A spicy, fishy, delight";
    public override Sprite Sprite => CreateSprite(MealsPath, "Spicy_Tuna_Salad.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 40;
    public override MealQuality Quality => MealQuality.NORMAL;
    public override int SatiationLevel => 2;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
          MealEffectType = FoodEffectRegistry.Get(nameof(RemoveTerrifiedEffect)),
          Chance = 40,
        },
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(GainSinFull)),
            Chance = 20,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.InstantlyPoop,
            Chance = 20
        }
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(DeathPepper)), 1),
            new InventoryItem(ItemRegistry.Get(nameof(Onion)), 1),
            new InventoryItem(InventoryItem.ITEM_TYPE.FISH, 3),
            new InventoryItem(InventoryItem.ITEM_TYPE.YOLK, 2),
        ],
    ];
}