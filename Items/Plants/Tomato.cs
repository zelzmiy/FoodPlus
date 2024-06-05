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
        public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
        public override string LocalizedName() => "Tomato";
        public override string LocalizedLore() => "Perfect for throwing";
        public override string LocalizedDescription() => "An ingrediant for a royal diet";

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "tomato.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "tomato.png"));

    }
}
