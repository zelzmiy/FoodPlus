using FoodPlus.Items;
using FoodPlus.Items.Dishes;
using Socket.Newtonsoft.Json;
using src.UI.InfoCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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
	private static MethodInfo _info => typeof(Resources).GetMethod(nameof(Resources.Load));

	[HarmonyPatch(typeof(RecipeInfoCard), nameof(RecipeInfoCard.Configure)), HarmonyPrefix]
	public static void AddCustomStarRating(RecipeInfoCard __instance, ITEM_TYPE config)
	{
		int satationLevel = GetSatationLevel(config);
		for (int index = 0; index < __instance._starFills.Length; ++index)
			__instance._starFills[index].SetActive(satationLevel >= index + 1);
	}

	[HarmonyPatch(typeof(ItemPickUp), nameof(ItemPickUp.GetItemPickUpObject)), HarmonyPostfix]
	public static void GetCorrectMealObject(ref GameObject __result, ITEM_TYPE type)
	{
		if (type is not ITEM_TYPE.MEAL or
					ITEM_TYPE.MEALS or
					ITEM_TYPE.MEAL_BAD_FISH or
					ITEM_TYPE.MEAL_BAD_MEAT or
					ITEM_TYPE.MEAL_BAD_MIXED or
					ITEM_TYPE.MEAL_BERRIES or
					ITEM_TYPE.MEAL_BURNED or
					ITEM_TYPE.MEAL_DEADLY or
					ITEM_TYPE.MEAL_EGG or
					ITEM_TYPE.MEAL_FOLLOWER_MEAT or
					ITEM_TYPE.MEAL_GOOD_FISH or
					ITEM_TYPE.MEAL_GRASS or
					ITEM_TYPE.MEAL_GREAT or
					ITEM_TYPE.MEAL_GREAT_FISH or
					ITEM_TYPE.MEAL_GREAT_MEAT or
					ITEM_TYPE.MEAL_GREAT_MIXED or
					ITEM_TYPE.MEAL_MEAT or
					ITEM_TYPE.MEAL_MEDIUM_MIXED or
					ITEM_TYPE.MEAL_MEDIUM_VEG or
					ITEM_TYPE.MEAL_MUSHROOMS or
					ITEM_TYPE.MEAL_POOP or
					ITEM_TYPE.MEAL_ROTTEN or
					ITEM_TYPE.MEAL_SPICY)
			return;

		GameObject _obj = new();
		GameManager.GetInstance().StartCoroutine(Plugin.GetOrLoadAsset(GetMealObjectPath(type), delegate (GameObject obj) 
		{ 
			_obj = obj;
		}));

		__result = _obj; // idk

	}

	public static string GetMealObjectPath(ITEM_TYPE item)
	{
		return item switch
		{
			ITEM_TYPE.MEAL => "Assets/Prefabs/Structures/Other/Meal.prefab",
			ITEM_TYPE.MEALS => "Assets/Prefabs/Structures/Other/Meals.prefab",
			ITEM_TYPE.MEAL_BAD_FISH => "Assets/Prefabs/Structures/Other/Meal Bad Fish.prefab",
			ITEM_TYPE.MEAL_BAD_MEAT => "Assets/Prefabs/Structures/Other/Meal Bad Meat.prefab",
			ITEM_TYPE.MEAL_BAD_MIXED => "Assets/Prefabs/Structures/Other/Meal Bad Mixed.prefab",
			ITEM_TYPE.MEAL_BERRIES => "Assets/Prefabs/Structures/Other/Meal Berries.prefab",
			ITEM_TYPE.MEAL_BURNED => "Assets/Prefabs/Structures/Other/Meal Burned.prefab",
			ITEM_TYPE.MEAL_DEADLY => "Assets/Prefabs/Structures/Other/Meal Deadly.prefab",
			ITEM_TYPE.MEAL_EGG => "Assets/Prefabs/Structures/Other/Meal Egg.prefab",
			ITEM_TYPE.MEAL_FOLLOWER_MEAT => "Assets/Prefabs/Structures/Other/Meal Follower Meat.prefab",
			ITEM_TYPE.MEAL_GOOD_FISH => "Assets/Prefabs/Structures/Other/Meal Good Fish.prefab",
			ITEM_TYPE.MEAL_GRASS => "Assets/Prefabs/Structures/Other/Meal Grass.prefab",
			ITEM_TYPE.MEAL_GREAT => "Assets/Prefabs/Structures/Other/Meal Great.prefab",
			ITEM_TYPE.MEAL_GREAT_FISH => "Assets/Prefabs/Structures/Other/Meal Great Fish.prefab",
			ITEM_TYPE.MEAL_GREAT_MEAT => "Assets/Prefabs/Structures/Other/Meal Great Meat.prefab",
			ITEM_TYPE.MEAL_GREAT_MIXED => "Assets/Prefabs/Structures/Other/Meal Great Mixed.prefab",
			ITEM_TYPE.MEAL_MEAT => "Assets/Prefabs/Structures/Other/Meal Good.prefab",
			ITEM_TYPE.MEAL_MEDIUM_MIXED => "Assets/Prefabs/Structures/Other/Meal Medium Mixed.prefab",
			ITEM_TYPE.MEAL_MEDIUM_VEG => "Assets/Prefabs/Structures/Other/Meal Medium Veg.prefab",
			ITEM_TYPE.MEAL_MUSHROOMS => "Assets/Prefabs/Structures/Other/Meal Mushrooms.prefab",
			ITEM_TYPE.MEAL_POOP => "Assets/Prefabs/Structures/Other/Meal Poop.prefab",
			ITEM_TYPE.MEAL_SPICY => "Assets/Prefabs/Structures/Other/Meal Spicy.prefab",
			_ => null
		};
	}
}