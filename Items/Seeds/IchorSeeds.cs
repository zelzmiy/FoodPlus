using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Plants
{
    internal class IchorSeeds : CustomInventoryItem
    {
        public override string InternalName => "Ichor_Seeds";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
        public override string LocalizedName() { return "Ichor Seeds"; }
        public override string LocalizedDescription() { return "A precursor the pain"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "ichor_seeds.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "ichor_seeds.png"));
        public override bool IsSeed => true;
        public override bool IsPlantable => true;

    }
}
