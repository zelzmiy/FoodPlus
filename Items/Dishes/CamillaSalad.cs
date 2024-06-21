using COTL_API.CustomInventory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CookingData;

namespace FoodPlus.Items.Dishes;

internal class CamillaSalad : CustomInventoryItem
{
    public override string InternalName => "Camilla_Salad";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.MEAL_BERRIES;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Camilla Salad";
    public override string LocalizedLore() => "Medbay in a bowl";
    public override string LocalizedDescription() => "A dish of flowers to heal your followers";
    public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "dishes", "Meal_Camilla_Salad.png"));
	public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "dishes", "Meal_Camilla_Salad.png"));
	public override bool IsFood => true;
	public override int FoodSatitation => 75;

	public static MealEffect[] MealEffects { get; } =
	[
		new MealEffect
		{
			MealEffectType = MealEffectType.HealsIllness,
			Chance = 100
		},
		new MealEffect
		{
			MealEffectType = MealEffectType.InstantlyVomit,
			Chance = 100
		},
	];

	public static List<List<InventoryItem>> Recipe { get; } =
	[
		[
			new (InventoryItem.ITEM_TYPE.FLOWER_RED, 5),
			new (InventoryItem.ITEM_TYPE.GRAPES, 3),
			new (InventoryItem.ITEM_TYPE.GRASS, 3),
		]
	];
}