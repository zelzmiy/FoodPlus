using FoodPlus.CropControllers;
using FoodPlus.Items;
using System;
using System.Collections.Generic;
using System.Text;
using static FoodPlus.CropControllers.CustomCropControllers;

namespace FoodPlus.Patches
{
    internal static class FarmPlotPatch
    {
        [HarmonyPatch(typeof(FarmPlot), "Awake"), HarmonyPostfix]
        private static void AddCustomControllerTypes(FarmPlot __instance, Dictionary<InventoryItem.ITEM_TYPE, CropController> ____cropPrefabsBySeedType) 
        {
            ____cropPrefabsBySeedType.Add(ItemRegistery.IchorSeeds, IchorCropController);
            ____cropPrefabsBySeedType.Add(ItemRegistery.Lettuce, LettuceCropController);
            ____cropPrefabsBySeedType.Add(ItemRegistery.Onion, OnionCropController);
            ____cropPrefabsBySeedType.Add(ItemRegistery.Tomato, TomatoCropController);
            ____cropPrefabsBySeedType.Add(ItemRegistery.Wheat, WheatCropController);
        }
    }
}
    