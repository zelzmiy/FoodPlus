using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;

namespace FoodPlus.Items.Seeds;

internal class IchorSeeds : CustomCrop
{
    public override string InternalName => "Ichor_Seeds";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
    public override InventoryItem.ITEM_CATEGORIES ItemCategory => InventoryItem.ITEM_CATEGORIES.SEEDS;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.ITEM;
    public override string LocalizedName() => "Ichor Seeds";
    public override string LocalizedLore() => "The beginning of evil";
    public override string LocalizedDescription() => "Plant this in a <color=yellow>Farm Plot</color>";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(SeedsPath, "Ichor_Seeds.png");
    
    public override List<Sprite> CropStates { get; } =
    [
        CreateSprite(CropsPath, "Ichor", "pepper_0.png"),
        CreateSprite(CropsPath, "Ichor", "pepper_1.png"),
        CreateSprite(CropsPath, "Ichor", "pepper_2.png"),
        CreateSprite(CropsPath, "Ichor", "pepper_3.png"),
        CreateSprite(CropsPath, "Ichor", "pepper_harvest.png"),
    ];

    public override float CropGrowthTime => 9f;
    public override float PickingTime => 1.5f;
    
    public override List<InventoryItem.ITEM_TYPE> HarvestResult =>
    [
        ItemRegistry.Get((nameof(DeathPepper))),
        ItemRegistry.Get(nameof(IchorSeeds)),
    ];
    public override Vector2Int CropCountToDropRange => new(6, 10);
    public override string HarvestText => "Harvest <color=#5D1D1D>Death Peppers</color>";
}