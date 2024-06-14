using COTL_API.CustomInventory;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPlus.Items.Plants;

internal class Onion : CustomInventoryItem
{
    public override string InternalName => "Onion_Plant";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Onion";
    public override string LocalizedLore() => "It's got layers";
    public override string LocalizedDescription() => "An Ingrediant in foriegn dishes";

    //used for inventory icons
    public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "onion.png"));

    //used for spawning object in the world
    public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "onion.png"));

}
