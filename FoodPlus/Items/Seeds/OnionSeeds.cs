using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;

namespace FoodPlus.Items.Seeds;

internal class OnionSeeds : CustomCrop
{
    public override string InternalName => "Onion_Seeds";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
    public override InventoryItem.ITEM_CATEGORIES ItemCategory => InventoryItem.ITEM_CATEGORIES.SEEDS;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.ITEM;
    public override string LocalizedName() => "Onion Bulb";
    public override string LocalizedLore() => "The beginning of tears";
    public override string LocalizedDescription() => "Plant this in a <color=yellow>Farm Plot</color>";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(SeedsPath, "Onion_Bulb.png");
    
    public override List<Sprite> CropStates { get; } =
    [
        CreateSprite(CropsPath, "Onion", "onion_0.png"),
        CreateSprite(CropsPath, "Onion", "onion_1.png"),
        CreateSprite(CropsPath, "Onion", "onion_2.png"),
        CreateSprite(CropsPath, "Onion", "onion_harvest.png"),
    ];

    public override float CropGrowthTime => 10f;
    public override float PickingTime => 2f;
    
    public override List<InventoryItem.ITEM_TYPE> HarvestResult =>
    [
        ItemRegistry.Get((nameof(Onion))),
        ItemRegistry.Get(nameof(OnionSeeds)),
    ];
    public override Vector2Int CropCountToDropRange => new(1, 4);
    public override string HarvestText => "Harvest <color=#cc72f2>Onion</color>";
    
    public override int DungeonChestMinAmount { get; } = 4;
    public override int DungeonChestMaxAmount { get; } = 12;
}