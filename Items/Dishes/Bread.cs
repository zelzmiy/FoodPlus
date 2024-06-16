using COTL_API.CustomInventory;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Sirenix.Serialization.Utilities;

namespace FoodPlus.Items.Dishes;
internal class Bread : CustomInventoryItem
{
    public override string InternalName => "Bread";
    public override string LocalizedName() { return "Bread"; }
    public override string LocalizedDescription() { return "Loaf"; }
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.FISH_OCTOPUS;

    //used for inventory icons
    public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "dishes", "bread.png"));

    //used for spawning object in the world
    public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "dishes", "bread.png"));

    public override bool CanBeRefined => true;

    public override int RefineryInputQty => 5;

    public override InventoryItem.ITEM_TYPE RefineryInput => ItemRegistery.Wheat;

    public override float CustomRefineryDuration => 32f;
}
