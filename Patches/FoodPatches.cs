using FoodPlus.Items;
using FoodPlus.Items.Dishes;
using Socket.Newtonsoft.Json;
using src.UI.InfoCards;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UIElements;
using static CookingData;
using static InventoryItem;

namespace FoodPlus.Patches;

[HarmonyPatch]
public class CookingDataPatches
{
	[HarmonyPatch(typeof(CookingData), nameof(GetRecipe)), HarmonyPostfix]
	public static void AddCustomRecepies(ref List<List<InventoryItem>> __result, ITEM_TYPE mealType)
	{
		if (__result.Count != 0)
			return;

		if (mealType == ItemRegistery.CamillaSalad)
			__result = CamillaSalad.Recipe;
	}

	[HarmonyPatch(typeof(CookingData), nameof(GetMealEffects)), HarmonyPostfix]
	public static void AddCustomMealEffects(ref MealEffect[] __result, ITEM_TYPE mealType)
	{
		if (__result.Length != 0)
			return;

		if (mealType == ItemRegistery.CamillaSalad)
			__result = CamillaSalad.MealEffects;
	}

	[HarmonyPatch(typeof(CookingData), nameof(GetAllMeals)), HarmonyPostfix]
	public static void AddCustomMeal(ref ITEM_TYPE[] __result)
	{
		ITEM_TYPE[] newResult = new ITEM_TYPE[__result.Length + ItemRegistery.AllMeals.Count];

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
	public static void GetCustomMealTummyRating(ref float __result, ITEM_TYPE meal)
	{
		if (meal == ItemRegistery.CamillaSalad)
			__result = 0.5f;
	}

	[HarmonyPatch(typeof(CookingData), nameof(GetSatationLevel)), HarmonyPostfix]
	public static void GetCustomSatiationLevel(ref int __result, ITEM_TYPE meal)
	{
		if (meal == ItemRegistery.CamillaSalad)
			__result = 2;
	}

}



[HarmonyPatch]
public class FoodRelatedPatches
{
	[HarmonyPatch(typeof(RecipeInfoCard), nameof(RecipeInfoCard.Configure)), HarmonyPrefix]
	public static void AddCustomStarRating(RecipeInfoCard __instance, ITEM_TYPE config)
	{
		int satationLevel = GetSatationLevel(config);
		for (int index = 0; index < __instance._starFills.Length; ++index)
			__instance._starFills[index].SetActive(satationLevel >= index + 1);
	}

	[HarmonyPatch(typeof(Resources), nameof(Resources.Load)), HarmonyPostfix]
	public static void Resource(string path)
	{ 
		LogInfo(path);
	}
}