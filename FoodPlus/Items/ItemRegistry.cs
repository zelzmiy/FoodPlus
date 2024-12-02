using System.Collections.Generic;
using COTL_API.CustomInventory;
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

    public static void RegisterAllItems()
    {
        RegisterFood();
        RegisterIngredients();
        RegisterSeeds();
    }

    private static void RegisterFood()
    {
        s_items.Add(nameof(CamillaSalad), CustomItemManager.Add(new CamillaSalad()));
    }

    private static void RegisterIngredients()
    {
        s_items.Add(nameof(Wheat), CustomItemManager.Add(new Wheat()));
    }

    private static void RegisterSeeds()
    {
        s_items.Add(nameof(WheatSeeds), CustomItemManager.Add(new WheatSeeds()));
    }
}