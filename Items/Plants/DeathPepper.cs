using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Plants
{
    internal class DeathPepper : CustomInventoryItem
    {
        public override string InternalName => "DeathPepper_Plant";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
        public override string LocalizedName() { return "Death Pepper"; }
        public override string LocalizedDescription() { return "As Spicy As Hell"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "pepper.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "pepper.png"));

    }
}
