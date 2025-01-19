using COTL_API.CustomInventory;
using FoodPlus.Items.Seeds;

namespace FoodPlus.Items.Ingredients;
[ItemToRegister]
public class Wheat : CustomInventoryItem
{
    public override string InternalName => "Wheat";
    
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Wheat";
    public override string LocalizedLore() => "Golden Grain";
    public override string LocalizedDescription() => "A crafting ingredient for high-carb diet";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(IngredientsPath, "Wheat.png");

    public override InventoryItem.ITEM_TYPE SeedType => ItemRegistry.Get(nameof(WheatSeeds));
}
