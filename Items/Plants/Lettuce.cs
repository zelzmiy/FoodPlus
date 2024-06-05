using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Plants
{
    internal class Lettuce : CustomInventoryItem
    {
        public override string InternalName => "Lettuce_Plant";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.BLACK_GOLD;
        public override string LocalizedName() { return "Lettuce"; }
        public override string LocalizedDescription() { return "Eat your leafy greens"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "lettuce.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "lettuce.png"));

    }
}
