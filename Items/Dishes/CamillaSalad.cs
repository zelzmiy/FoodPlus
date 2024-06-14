using COTL_API.CustomInventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPlus.Items.Dishes;

internal class CamillaSalad : CustomInventoryItem
{
    public override string InternalName => "Wheat_Plant";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Wheat";
    public override string LocalizedLore() => "Golden Grain";
    public override string LocalizedDescription() => "A crafting ingrediant for high-carb diet";

    //used for inventory icons
    public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "wheat.png"));

    //used for spawning object in the world
    public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "wheat.png"));
}