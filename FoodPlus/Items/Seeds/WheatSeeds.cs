using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;

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
    public override Sprite Sprite => CreateSprite(SeedsPath, "Wheat_Seeds.png");
    
    public override List<Sprite> CropStates { get; } =
    [
        CreateSprite(CropsPath, "Wheat", "wheat_0.png"),
        CreateSprite(CropsPath, "Wheat", "wheat_1.png"),
        CreateSprite(CropsPath, "Wheat", "wheat_2.png"),
        CreateSprite(CropsPath, "Wheat", "wheat_3.png"),
        CreateSprite(CropsPath, "Wheat", "wheat_harvest.png"),
    ];

    public override float CropGrowthTime => 9f;
    public override float PickingTime => 1.5f;
    
    public override List<InventoryItem.ITEM_TYPE> HarvestResult =>
    [
        ItemRegistry.Get((nameof(Wheat))),
        ItemRegistry.Get(nameof(WheatSeeds)),
    ];
    public override Vector2Int CropCountToDropRange => new(8, 15);
    public override string HarvestText => "Pick <color=#CACB39>Wheat</color>";
    
    public override int DungeonChestMinAmount => 10;
    public override int DungeonChestMaxAmount => 18;
}