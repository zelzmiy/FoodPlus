using FoodPlus.Items;
using System;
using System.Collections.Generic;
using System.Text;
using static FoodPlus.CustomCropControllers;

namespace FoodPlus.Patches
{
    [HarmonyPatch]
    internal static class FarmPlotPatch
    {
        [HarmonyPatch(typeof(FarmPlot), "Awake"), HarmonyPostfix]
        private static void AddCustomControllerTypes(FarmPlot __instance, Dictionary<InventoryItem.ITEM_TYPE, CropController> ____cropPrefabsBySeedType) 
        {
            LogInfo("ADDING THE SHIT TO THE THING!!");
            //____cropPrefabsBySeedType.Add(ItemRegistery.IchorSeeds, IchorCropController);
            //____cropPrefabsBySeedType.Add(ItemRegistery.LettuceSeeds, LettuceCropController);
            //____cropPrefabsBySeedType.Add(ItemRegistery.OnionBulb, OnionCropController);
            //____cropPrefabsBySeedType.Add(ItemRegistery.TomatoSeeds, TomatoCropController);
            //____cropPrefabsBySeedType.Add(ItemRegistery.WheatSeeds, WheatSeedController);
        }
    }
}
    