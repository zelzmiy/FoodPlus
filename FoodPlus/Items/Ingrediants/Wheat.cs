using System.IO;
using COTL_API.CustomInventory;

namespace FoodPlus.Items.Ingrediants;

public class Wheat : CustomInventoryItem
{
    public override string InternalName { get; } = "Wheat";
    
    public override InventoryItem.ITEM_TYPE ItemPickUpToImitate => InventoryItem.ITEM_TYPE.CAULIFLOWER;
    public override CustomInventoryItemType InventoryItemType => CustomInventoryItemType.FOOD;
    public override string LocalizedName() => "Wheat";
    public override string LocalizedLore() => "Golden Grain";
    public override string LocalizedDescription() => "A crafting ingredient for high-carb diet";

    //used for inventory icons
    public override Sprite InventoryIcon => Sprite;

    //used for spawning object in the world
    public override Sprite Sprite => 
        TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "plants", "wheat.png"));
}
