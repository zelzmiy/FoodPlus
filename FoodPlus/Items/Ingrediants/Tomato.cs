using COTL_API.CustomInventory;
using FoodPlus.Items.Seeds;

namespace FoodPlus.Items.Ingrediants;

public class Tomato : CustomInventoryItem
{
    public override string InternalName => "Tomato";
    
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Tomato";
    public override string LocalizedLore() => "Crimson Flesh";
    public override string LocalizedDescription() => "A sweet ball for throwing";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(IngredientsPath, "Tomato.png");

    public override InventoryItem.ITEM_TYPE SeedType => ItemRegistry.Get(nameof(TomatoSeeds));
}
