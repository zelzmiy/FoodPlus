using COTL_API.CustomInventory;

namespace FoodPlus.Items.Ingredients;

[ItemToRegister]
public class Bread : CustomInventoryItem
{
    public override string InternalName => "Bread";
    
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    
    public override string LocalizedName() => "Bread";
    
    public override string LocalizedLore() => "Loaf";  
    public override string LocalizedDescription() => "A high-carb diet";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(IngredientsPath, "Bread.png");

    public override int RefineryInputQty => 5;

    public override InventoryItem.ITEM_TYPE RefineryInput => ItemRegistry.Get(nameof(Wheat));

    public override float CustomRefineryDuration => 32f;
}