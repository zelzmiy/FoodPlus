using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;

namespace FoodPlus.Items.Food.Meals;

public class HatefulDish : CustomMeal
{
    public override string InternalName => "Hateful_Dish";
    public override float TummyRating => 0.15f;
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Hateful Dish";
    public override string LocalizedLore() => "Filled with malice";
    public override string LocalizedDescription() => "Onion-infused fertilizer filled with afterlife spice";
    public override Sprite Sprite => CreateSprite(MealsPath, "Hateful_Dish.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 0;
    public override MealQuality Quality => MealQuality.GOOD;
    public override int SatiationLevel => 0;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
            MealEffectType = CookingData.MealEffectType.CausesDissent,
            Chance = 100
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(InventoryItem.ITEM_TYPE.POOP, 3),
            new InventoryItem(ItemRegistry.Get(nameof(DeathPepper)), 1),
            new InventoryItem(ItemRegistry.Get(nameof(Onion)), 1),
        ]
    ];
}