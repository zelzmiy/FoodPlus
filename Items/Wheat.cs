using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items
{
    internal class Wheat : CustomInventoryItem
    {
        public override string InternalName => "Wheat_Plant";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
        public override string LocalizedName() { return "Wheat"; }
        public override string LocalizedDescription() { return "Golden Grain"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "wheat.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "wheat.png"));

    }
}
