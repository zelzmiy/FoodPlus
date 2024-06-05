using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Plants
{
    internal class OnionBulb : CustomInventoryItem
    {
        public override string InternalName => "Onion_Seed";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
        public override string LocalizedName() { return "Onion Bulb"; }
        public override string LocalizedDescription() { return "Tastes like an onion!"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "onion_bulb.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "onion_bulb.png"));
        public override bool IsSeed => true;
        public override bool IsPlantable => true;

    }
}
