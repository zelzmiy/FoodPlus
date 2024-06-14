using COTL_API.CustomInventory;
using FoodPlus.Items.Dishes;
using FoodPlus.Items.Plants;
using FoodPlus.Items.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPlus.Items;

public class ItemRegistery
{
    /* Seeds */
    public static InventoryItem.ITEM_TYPE IchorSeeds;
    public static InventoryItem.ITEM_TYPE LettuceSeeds;
    public static InventoryItem.ITEM_TYPE OnionBulb;
    public static InventoryItem.ITEM_TYPE TomatoSeeds;
    public static InventoryItem.ITEM_TYPE WheatSeeds;

    /* Fruit */
    public static InventoryItem.ITEM_TYPE DeathPepper;
    public static InventoryItem.ITEM_TYPE Lettuce;
    public static InventoryItem.ITEM_TYPE Onion;
    public static InventoryItem.ITEM_TYPE Tomato;
    public static InventoryItem.ITEM_TYPE Wheat;

    /* processed/cooked*/
    public static InventoryItem.ITEM_TYPE Bread;

    public static void AddAllItems()
    {
        AddSeeds();
        AddPlants();
        AddDishes();
    }

    private static void AddDishes()
    {
        Bread = CustomItemManager.Add(new Bread());
    }

    private static void AddPlants()
    {
        IchorSeeds = CustomItemManager.Add(new IchorSeeds());
        LettuceSeeds = CustomItemManager.Add(new LettuceSeeds());
        OnionBulb = CustomItemManager.Add(new OnionBulb());
        TomatoSeeds = CustomItemManager.Add(new TomatoSeeds());
        WheatSeeds = CustomItemManager.Add(new WheatSeeds());
    }

    private static void AddSeeds()
    {
        DeathPepper = CustomItemManager.Add(new DeathPepper());
        Lettuce = CustomItemManager.Add(new Lettuce());
        Onion = CustomItemManager.Add(new Onion());
        Tomato = CustomItemManager.Add(new Tomato());
        Wheat = CustomItemManager.Add(new Wheat());
    }
}
