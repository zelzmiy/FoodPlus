using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Ingrediants;

namespace FoodPlus.Items.Seeds;

internal class TomatoSeeds : CustomCrop
{
    public override string InternalName => "Tomato_Seeds";
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.SEEDS;
    public override InventoryItem.ITEM_CATEGORIES ItemCategory => InventoryItem.ITEM_CATEGORIES.SEEDS;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.ITEM;
    public override string LocalizedName() => "Tomato Seeds";
    public override string LocalizedLore() => "The start to mockery";
    public override string LocalizedDescription() => "Plant this in a <color=yellow>Farm Plot</color>";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(SeedsPath, "Tomato_Seeds.png");
    
    public override List<Sprite> CropStates { get; } =
    [
        CreateSprite(CropsPath, "Tomato", "tomato_1.png"),
        CreateSprite(CropsPath, "Tomato", "tomato_2.png"),
        CreateSprite(CropsPath, "Tomato", "tomato_3.png"),
        CreateSprite(CropsPath, "Tomato", "tomato_4.png"),
        CreateSprite(CropsPath, "Tomato", "tomato_harvest.png"),
    ];

    public override float CropGrowthTime => 8f;
    public override float PickingTime => 2f;
    
    public override List<InventoryItem.ITEM_TYPE> HarvestResult =>
    [
        ItemRegistry.Get((nameof(Tomato))),
        ItemRegistry.Get(nameof(TomatoSeeds)),
    ];
    public override Vector2Int CropCountToDropRange => new(3, 6);
    public override string HarvestText => "Pick <color=#CD4040>Tomatoes</color>";
    
    public override int DungeonChestMinAmount => 12;
    public override int DungeonChestMaxAmount => 20;
}