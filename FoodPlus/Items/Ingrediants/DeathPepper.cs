using COTL_API.CustomInventory;
using FoodPlus.Items.Seeds;

namespace FoodPlus.Items.Ingrediants;

public class DeathPepper : CustomInventoryItem
{
    public override string InternalName => "Death_Pepper";
    
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Death Pepper";
    public override string LocalizedLore() => "Evil Flesh";
    public override string LocalizedDescription() => "A spicy afterlife fruit";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => CreateSprite(IngredientsPath, "DeathPepper.png");

    public override InventoryItem.ITEM_TYPE SeedType => ItemRegistry.Get(nameof(DeathPepper));
}
