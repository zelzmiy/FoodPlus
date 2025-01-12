using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food.Meals;

public class ItalianDish : CustomMeal
{
    public override string InternalName => "Italian_Dish";
    public override float TummyRating => 1f;
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Spaghetti & Meatballs";
    public override string LocalizedLore() => "Eyeballs notwithstanding";
    public override string LocalizedDescription() => "A romantic dish for dogs and followers";
    public override Sprite Sprite => CreateSprite(MealsPath, "Italian_Dish.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 67;
    public override MealQuality Quality => MealQuality.GOOD;
    public override int SatiationLevel => 3;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(FallInLoveEffect)),
            Chance = 100,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.CausesIllness,
            Chance = 30,
        }
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(Wheat)), 15),
            new InventoryItem(ItemRegistry.Get(nameof(Tomato)), 3),
            new InventoryItem(InventoryItem.ITEM_TYPE.MEAT, 2),
            new InventoryItem(InventoryItem.ITEM_TYPE.YOLK, 1),
        ]
    ];
}