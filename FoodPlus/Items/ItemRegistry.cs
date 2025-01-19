using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using COTL_API.CustomInventory;
using FoodPlus.CustomTraits;
using FoodPlus.Items.Food;
using FoodPlus.Items.Food.Drinks;
using FoodPlus.Items.Food.Meals;
using FoodPlus.Items.Ingredients;
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

    #region Registration Methods

    private static void RegisterDrinks()
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttribute<DrinkToRegister>() != null)
            .Do((type) =>
            {
                s_items.Add(type.Name, CustomItemManager.Add((CustomDrink)Activator.CreateInstance(type)));
            });
    }

    private static void RegisterMeals()
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttribute<MealToRegister>() != null)
            .Do((type) =>
            {
                s_items.Add(type.Name, CustomItemManager.Add((CustomMeal)Activator.CreateInstance(type)));
            });
    }

    private static void RegisterIngredients()
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttribute<ItemToRegister>() != null)
            .Do((type) =>
            {
                s_items.Add(type.Name, CustomItemManager.Add((CustomInventoryItem)Activator.CreateInstance(type)));
            });
    }

    private static void RegisterSeeds()
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttribute<CropToRegister>() != null)
            .Do((type) =>
            {
                s_items.Add(type.Name, CustomItemManager.Add((CustomCrop)Activator.CreateInstance(type)));
            });
    }

    #endregion
}