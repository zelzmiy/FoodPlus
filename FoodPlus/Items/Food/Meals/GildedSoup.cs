using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;
using FoodPlus.MealEffects;
using src.UI.InfoCards;

namespace FoodPlus.Items.Food.Meals;

[HarmonyPatch]
public class GildedSoup : CustomMeal
{
    public override string InternalName => "Gilded_Soup";
    public override float TummyRating => 0.5f;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Gilded Soup";
    public override string LocalizedLore() => "";
    public override string LocalizedDescription() => 
        "<size=22><sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_21\">" +
        "<sprite name=\"IconTexture_32\">" +
        "<sprite name=\"IconTexture_31\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_17\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_19\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_29\">" +
        "<sprite name=\"IconTexture_32\">" +
        "<sprite name=\"IconTexture_21\">" +
        "<sprite name=\"IconTexture_18\">" +
        "<sprite name=\"IconTexture_17\">" +
        "<sprite name=\"IconTexture_17\">" +
        "<sprite name=\"IconTexture_26\">" +
        "<sprite name=\"IconTexture_29\">";
    public override Sprite Sprite => CreateSprite(MealsPath, "Gilded_Soup.png");
    public override Sprite InventoryIcon => Sprite;
    public override bool IsFood => true;
    public override int FoodSatitation => 40;
    public override MealQuality Quality => MealQuality.NORMAL;
    public override int SatiationLevel => 2;

    public override CookingData.MealEffect[] MealEffects { get; } =
    [
        new()
        {
          MealEffectType = FoodEffectRegistry.Get(nameof(GainRoyalPooperTraitEffect)),
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
            new InventoryItem(InventoryItem.ITEM_TYPE.BLACK_GOLD, 80),
            new InventoryItem(InventoryItem.ITEM_TYPE.GOLD_NUGGET, 15),
            new InventoryItem(InventoryItem.ITEM_TYPE.GOLD_REFINED, 6),
            new InventoryItem(InventoryItem.ITEM_TYPE.FOLLOWER_MEAT, 4),
            new InventoryItem(InventoryItem.ITEM_TYPE.GOD_TEAR, 1),
        ],
    ];
    
}