using COTL_API.CustomInventory;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPlus.Items.Plants
{
    internal class Onion : CustomInventoryItem
    {
        public override string InternalName => "Onion_Plant";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
        public override string LocalizedName() { return "Onion"; }
        public override string LocalizedDescription() { return "It's got layers"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "onion.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "onion.png"));

    }
}
