using COTL_API.CustomInventory;
using System.IO;

namespace FoodPlus.Items.Seeds
{
    internal class TomatoSeeds : CustomInventoryItem
    {
        public override string InternalName => "Tomato_Seeds";
        public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
        public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.ITEM;
        public override string LocalizedName() =>"Tomato Seeds"; 
        public override string LocalizedLore() => "A precursor to movie criticism";
        public override string LocalizedDescription() => "Plant this in a <color=yellow>Farm Plot</color>";

        //used for inventory icons
        public override Sprite InventoryIcon => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "tomato_seeds.png"));

        //used for spawning object in the world
        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "tomato_seeds.png"));
        public override bool IsSeed => true;
        public override bool IsPlantable => true;

    }
}
