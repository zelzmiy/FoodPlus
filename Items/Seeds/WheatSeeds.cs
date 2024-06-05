using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Plants
{
    internal class WheatSeeds : CustomInventoryItem
    {
        public override string InternalName => "Wheat_Seeds";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
        public override string LocalizedName() { return "Wheat Seeds"; }
        public override string LocalizedDescription() { return "The begining of everything"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "wheat_seeds.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "wheat_seeds.png"));
        public override bool IsSeed => true;
        public override bool IsPlantable => true;

    }
}
