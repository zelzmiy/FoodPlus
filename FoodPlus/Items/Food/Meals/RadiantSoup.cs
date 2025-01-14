using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;
using src.UI.InfoCards;

namespace FoodPlus.Items.Food.Meals;

[HarmonyPatch]
public class RadiantSoup : CustomMeal
{
    public override string InternalName => "Radiant_Soup";
    public override float TummyRating => 0.5f;
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Radiant Soup";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => 
        "<size=22><sprite name=\"IconTexture_19\">" +
        "<sprite name=\"IconTexture_21\">" +
        "<sprite name=\"IconTexture_32\">" +
        "<sprite name=\"IconTexture_31\">" +
        "<sprite name=\"IconTexture_16\">" +
        "<sprite name=\"IconTexture_17\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_17\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_29\">" +
        "<sprite name=\"IconTexture_32\">" +
        "<sprite name=\"IconTexture_23\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_19\">" +
        "<sprite name=\"IconTexture_121\">" +
        "<sprite name=\"IconTexture_26\">" +
        "<sprite name=\"IconTexture_28\">";
    public override Sprite Sprite => CreateSprite(MealsPath, "Radiant_Soup.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 40;
    public override MealQuality Quality => MealQuality.NORMAL;
    public override int SatiationLevel => 2;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
          MealEffectType = FoodEffectRegistry.Get(nameof(GainNeonPooperTraitEffect)),
          Chance = 100,
        },
        new()
        {
            MealEffectType = CookingData.MealEffectType.InstantlyDie,
            Chance = 10,
        },
    ];

    public override List<List<InventoryItem>> Recipe { get; } =
    [
        [
            new InventoryItem(InventoryItem.ITEM_TYPE.BONE, 40),
            new InventoryItem(InventoryItem.ITEM_TYPE.CRYSTAL, 25),
            new InventoryItem(InventoryItem.ITEM_TYPE.GRAPES, 18),
            new InventoryItem(InventoryItem.ITEM_TYPE.FOLLOWER_MEAT, 4),
            new InventoryItem(InventoryItem.ITEM_TYPE.GOD_TEAR, 1),
        ],
    ];
}