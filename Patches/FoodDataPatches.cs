using FoodPlus.Items;
using FoodPlus.Items.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UIElements;
using static CookingData;

namespace FoodPlus.Patches;

[HarmonyPatch]
public class CookingDataPatches
{
	[HarmonyPatch(typeof(CookingData), nameof(GetRecipe)), HarmonyPostfix]
	public static void AddCustomRecepies(ref List<List<InventoryItem>> __result, object[] __args)
	{
		var item = (InventoryItem.ITEM_TYPE)__args[0];

		if (__result.Count != 0)
			return;

		if (item == ItemRegistery.CamillaSalad)
			__result = CamillaSalad.Recipe;
	}

	[HarmonyPatch(typeof(CookingData), nameof(GetMealEffects)), HarmonyPostfix]
	public static void AddCustomMealEffects(ref MealEffect[] __result, object[] __args)
	{
		if (__result.Length != 0)
			return;

		var item = (InventoryItem.ITEM_TYPE)__args[0];

		if (item == ItemRegistery.CamillaSalad)
			__result = CamillaSalad.MealEffects;
	}

	[HarmonyPatch(typeof(CookingData), nameof(GetAllMeals)), HarmonyPostfix]
	public static void AddCustomMeal(ref InventoryItem.ITEM_TYPE[] __result)
	{
		InventoryItem.ITEM_TYPE[] newResult = new InventoryItem.ITEM_TYPE[__result.Length + ItemRegistery.AllMeals.Count];

		for (int i = 0; i < __result.Length; i++)
		{
			newResult[i] = __result[i];
		}

		for (int i = 0; i < ItemRegistery.AllMeals.Count; i++)
		{
			newResult[__result.Length + i] = ItemRegistery.AllMeals[i];
		}

		__result = newResult;
	}

	[HarmonyPatch(typeof(CookingData), nameof(GetTummyRating)), HarmonyPostfix]
	public static void GetCustomMealTummyRating(ref float __result, object[] __args)
	{
		var item = (InventoryItem.ITEM_TYPE)__args[0];

		LogInfo($"getting tummy rating, {item}");
		if (item == ItemRegistery.CamillaSalad)
			__result = 0.5f;
	}

}
