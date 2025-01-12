using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;

namespace FoodPlus.Items.Food.Meals;

public class FrenchToast : CustomMeal
{
    public override string InternalName => "French_Toast";
    public override float TummyRating => 1f;
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "French Toast";
    public override string LocalizedLore() => "Sweet Carbs";
    public override string LocalizedDescription() => "Egg infused bread toasted to perfection";
    public override Sprite Sprite => CreateSprite(MealsPath, "French_Toast.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 75;
    public override MealQuality Quality => MealQuality.GOOD;
    public override int SatiationLevel => 3;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = FoodEffectRegistry.Get(nameof(RemoveSpyEffect)),
            Chance = 100
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(ItemRegistry.Get(nameof(Bread)),1),
            new InventoryItem(InventoryItem.ITEM_TYPE.YOLK, 1),
        ]
    ];
}