using COTL_API.CustomInventory;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPlus.Items.Plants
{
    internal class Tomato : CustomInventoryItem
    {
        public override string InternalName => "Tomato_Plant";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
        public override string LocalizedName() { return "Tomato"; }
        public override string LocalizedDescription() { return "Perfect for throwing"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "tomato.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "tomato.png"));

    }
}
