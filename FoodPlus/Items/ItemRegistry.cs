using System.Collections.Generic;
using COTL_API.CustomInventory;
using FoodPlus.Items.Food;
using FoodPlus.Items.Food.Drinks;
using FoodPlus.Items.Food.Meals;
using FoodPlus.Items.Ingrediants;
using FoodPlus.Items.Seeds;

namespace FoodPlus.Items;

public static class ItemRegistry
{
    private static readonly Dictionary<string, InventoryItem.ITEM_TYPE> s_items = [];
    
    public static InventoryItem.ITEM_TYPE Get(string itemName) 
    {
        return s_items[itemName];
    }
    
    public static void RegisterItems()
    {
        // I may have to switch to lazy loading since things have to be registered at a very specific order
        // specifically ingredients before food, since food needs ingredients for recipe
        RegisterSeeds();
        RegisterIngredients();
        RegisterMeals();
        RegisterDrinks();
    }

    private static void RegisterDrinks()
    {
        s_items.Add(nameof(TomatoJuice), CustomItemManager.Add(new TomatoJuice()));
        s_items.Add(nameof(Whiskey), CustomItemManager.Add(new Whiskey()));
    }

    private static void RegisterMeals()
    {
        s_items.Add(nameof(SpicyTunaSalad), CustomItemManager.Add(new SpicyTunaSalad()));
        s_items.Add(nameof(DionysianSalad), CustomItemManager.Add(new DionysianSalad()));
        s_items.Add(nameof(OldOnesSalad), CustomItemManager.Add(new OldOnesSalad()));
        s_items.Add(nameof(CamillaSalad), CustomItemManager.Add(new CamillaSalad()));
        s_items.Add(nameof(FrenchToast), CustomItemManager.Add(new FrenchToast()));
        s_items.Add(nameof(HatefulDish), CustomItemManager.Add(new HatefulDish()));
        s_items.Add(nameof(ItalianDish), CustomItemManager.Add(new ItalianDish()));
        s_items.Add(nameof(RadiantSoup), CustomItemManager.Add(new RadiantSoup()));
        s_items.Add(nameof(GildedSoup), CustomItemManager.Add(new GildedSoup()));
        s_items.Add(nameof(SpicyTacos), CustomItemManager.Add(new SpicyTacos()));
        s_items.Add(nameof(GrassRoll), CustomItemManager.Add(new GrassRoll()));
        s_items.Add(nameof(Burger), CustomItemManager.Add(new Burger()));
    }

    private static void RegisterIngredients()
    {
        s_items.Add(nameof(DeathPepper), CustomItemManager.Add(new DeathPepper()));
        s_items.Add(nameof(Tomato), CustomItemManager.Add(new Tomato()));
        s_items.Add(nameof(Wheat), CustomItemManager.Add(new Wheat()));
        s_items.Add(nameof(Onion), CustomItemManager.Add(new Onion()));
        
        s_items.Add(nameof(Bread), CustomItemManager.Add(new Bread()));
    }

    private static void RegisterSeeds()
    {
        s_items.Add(nameof(TomatoSeeds), CustomItemManager.Add(new TomatoSeeds()));
        s_items.Add(nameof(WheatSeeds), CustomItemManager.Add(new WheatSeeds()));
        s_items.Add(nameof(OnionSeeds), CustomItemManager.Add(new OnionSeeds()));
        s_items.Add(nameof(IchorSeeds), CustomItemManager.Add(new IchorSeeds()));
    }
}