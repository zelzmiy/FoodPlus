using COTL_API.Prefabs;
using FoodPlus.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static FoodPlus.CustomCropControllers;

namespace FoodPlus.Patches;

[HarmonyPatch]
internal static class FarmPlotPatch
{
	[HarmonyPatch(typeof(CropController), nameof(CropController.SetCropImage)), HarmonyPrefix]
	public static void DoLogs(CropController __instance)
	{
	if (__instance.SeedType != ItemRegistery.WheatSeeds)
		return;

	LogInfo($"{nameof(__instance.SeedType)}: {__instance.SeedType}");
	LogInfo($"{nameof(__instance.BumperCropObject)} null?: {__instance.BumperCropObject == null}");
	LogInfo($"{nameof(__instance.CropStates)} null?: {__instance.CropStates == null}");
	LogInfo($"{nameof(__instance.CropStates)} count?: {__instance.CropStates.Count}");
	LogInfo($"{nameof(__instance.GrowRateIcons)} null?: {__instance.GrowRateIcons == null}");
	LogInfo($"{nameof(__instance.growth)} value?: {__instance.growth}");
	}

	[HarmonyPatch(typeof(FarmPlot), "Awake"), HarmonyPrefix]
	private static void AddCustomControllerTypes(FarmPlot __instance, List<CropController> ___CropPrefabs)
	{
	foreach (GameObject goj in WheatCropController.CropStates)
	{
	goj.transform.position = __instance.transform.position;
	}

	___CropPrefabs.Add(WheatCropController);
	}
}
