using COTL_API.CustomInventory;
using FoodPlus.Items.Seeds;

namespace FoodPlus.Items.Ingredients;
[ItemToRegister]
public class Onion : CustomInventoryItem
{
    public override string InternalName => "Onion";
    
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Onion";
    public override string LocalizedLore() => "Layered, Like an Ogre";
    public override string LocalizedDescription() => "A common white onion.";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(IngredientsPath, "Onion.png");

    public override InventoryItem.ITEM_TYPE SeedType => ItemRegistry.Get(nameof(OnionSeeds));
}

