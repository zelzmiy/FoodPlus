using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items
{
    internal class TomatoSeeds : CustomInventoryItem
    {
        public override string InternalName => "Tomato_Seeds";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
        public override string LocalizedName() { return "Tomato Seeds"; }
        public override string LocalizedDescription() { return "A Precursor to movie criticism"; }

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets","seeds", "tomato_seeds.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets","seeds" , "tomato_seeds.png"));
        public override bool IsSeed => true;
        public override bool IsPlantable => true;

    }
}
