using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Plants
{
    internal class LettuceSeeds : CustomInventoryItem
    {
        public override string InternalName => "Lettuce_Seeds";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
        public override string LocalizedName() { return "Lettuce Seeds"; }
        public override string LocalizedDescription() { return "A precursor to bnnuy"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "lettuce_seeds.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "lettuce_seeds.png"));
        public override bool IsSeed => true;
        public override bool IsPlantable => true;

    }
}
