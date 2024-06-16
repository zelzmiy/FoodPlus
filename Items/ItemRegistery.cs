using COTL_API.CustomInventory;
using FoodPlus.Items.Dishes;
using FoodPlus.Items.Plants;
using FoodPlus.Items.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

using static InventoryItem;
using static COTL_API.CustomInventory.CustomItemManager;

namespace FoodPlus.Items;

public class ItemRegistery
{
    /* Seeds */
    public static ITEM_TYPE IchorSeeds;
    public static ITEM_TYPE LettuceSeeds;
    public static ITEM_TYPE OnionBulb;
    public static ITEM_TYPE TomatoSeeds;
    public static ITEM_TYPE WheatSeeds;

    /* Fruit */
    public static ITEM_TYPE DeathPepper;
    public static ITEM_TYPE Lettuce;
    public static ITEM_TYPE Onion;
    public static ITEM_TYPE Tomato;
    public static ITEM_TYPE Wheat;

    /* processed/cooked*/
    public static ITEM_TYPE Bread;
    public static ITEM_TYPE CamillaSalad;
    public static List<ITEM_TYPE> AllMeals = [];

    public static void AddAllItems()
    {
        AddSeeds();
        AddPlants();
        AddDishes();
    }

    private static void AddDishes()
    {
        Bread = Add(new Bread());
        CamillaSalad = Add(new CamillaSalad());

        AllMeals.Add(CamillaSalad);

		CookingData.TryDiscoverRecipe(CamillaSalad);
    }

    private static void AddSeeds()
    {
        IchorSeeds = Add(new IchorSeeds());
        LettuceSeeds = Add(new LettuceSeeds());
        OnionBulb = Add(new OnionBulb());
        TomatoSeeds = Add(new TomatoSeeds());
        WheatSeeds = Add(new WheatSeeds());
    }

    private static void AddPlants()
    {
        DeathPepper = Add(new DeathPepper());
        Lettuce = Add(new Lettuce());
        Onion = Add(new Onion());
        Tomato = Add(new Tomato());
        Wheat = Add(new Wheat());
    }
}
