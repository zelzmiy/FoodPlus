using System.Collections.Generic;
using COTL_API.CustomInventory;

namespace FoodPlus.Items.Seeds;

public class GrassSeeds : CustomCrop
{
    public override string InternalName => "Grass_Seeds";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
    public override InventoryItem.ITEM_CATEGORIES ItemCategory => InventoryItem.ITEM_CATEGORIES.SEEDS;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.ITEM;
    public override string LocalizedName() => "Grass Seeds";
    public override string LocalizedLore() => "Grows Turf";
    public override string LocalizedDescription() => "Plant this in a <color=yellow>Farm Plot</color>";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(SeedsPath, "Grass_Seeds.png");
    
    public override List<Sprite> CropStates { get; } =
    [
        CreateSprite(CropsPath, "Grass", "grass_0.png"),
        CreateSprite(CropsPath, "Grass", "grass_1.png"),
        CreateSprite(CropsPath, "Grass", "grass_2.png"),
        CreateSprite(CropsPath, "Grass", "grass_3.png"),
        CreateSprite(CropsPath, "Grass", "grass_harvest.png"),
    ];

    public override float CropGrowthTime => 6f;
    public override float PickingTime => 1f;
    
    public override List<InventoryItem.ITEM_TYPE> HarvestResult =>
    [
        InventoryItem.ITEM_TYPE.GRASS,
        ItemRegistry.Get(nameof(GrassSeeds)),
    ];
    public override Vector2Int CropCountToDropRange => new(8, 12);
    public override string HarvestText => "Harvest <color=#8eF48e>Grass</color>";
    
    public override int DungeonChestMinAmount => 12;
    public override int DungeonChestMaxAmount => 18;
}