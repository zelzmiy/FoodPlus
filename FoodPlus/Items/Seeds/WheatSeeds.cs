using System;
using System.Collections.Generic;
using COTL_API.CustomInventory;
using System.IO;
using FoodPlus.Items.Ingrediants;
using static FoodPlus.Helpers.CropHelper;

namespace FoodPlus.Items.Seeds;

internal class WheatSeeds : CustomCrop
{
    public override string InternalName => "Wheat_Seeds";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
    public override InventoryItem.ITEM_CATEGORIES ItemCategory => InventoryItem.ITEM_CATEGORIES.SEEDS;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.ITEM;
    public override string LocalizedName() => "Wheat Seeds";
    public override string LocalizedLore() => "The beginning of everything";
    public override string LocalizedDescription() => "Plant this in a <color=yellow>Farm Plot</color>";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => 
        TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "seeds", "wheat_seeds.png"));

    public override Vector2Int HarvestsPerSeedRange { get; } = new(4, 8);

    public override List<Sprite> CropStates { get; } =
        [
            MakeCropSprite("wheat_0.png"),
            MakeCropSprite("wheat_1.png"),
            MakeCropSprite("wheat_2.png"),
            MakeCropSprite("wheat_structure.png"),
        ];
    
    
    public override float CropGrowthTime => 1f;
    
    public override DropMultipleLootOnDeath.ItemAndProbability[] HarvestResult => 
        [
            new(ItemRegistry.Get(nameof(Wheat)), 80),
            new(ItemRegistry.Get(nameof(WheatSeeds)), 100),
        ];
    
    public override int ProgressTarget => 3;
    public override Vector2Int CropCountToDropRange => new(6, 10);
}