using FoodPlus.Items;
using System;
using System.Collections.Generic;
using System.Text;
using static InventoryItem;
using static FoodPlus.Items.ItemRegistery;

namespace FoodPlus.Patches
{
    internal static class CropControllerPatch
    {

        [HarmonyPatch(typeof(CropController), nameof(CropController.CropGrowthTimes)), HarmonyPostfix]
        private static void AddCustomCropTypes(ITEM_TYPE __seedType, ref float __result)
        {
            if (__seedType is
                ITEM_TYPE.SEED or
                ITEM_TYPE.SEED_PUMPKIN or
                ITEM_TYPE.SEED_COTTON or
                ITEM_TYPE.SEED_GRAPES or
                ITEM_TYPE.SEED_BEETROOT or
                ITEM_TYPE.SEED_CAULIFLOWER or
                ITEM_TYPE.SEED_HOPS or
                ITEM_TYPE.SEED_MUSHROOM or
                ITEM_TYPE.SEED_SOZO)
            {
                return;
            }

            if (__seedType == IchorSeeds) __result = 24f;
            if (__seedType == LettuceSeeds) __result = 12f;
            if (__seedType == OnionBulb) __result = 15f;
            if (__seedType == TomatoSeeds) __result = 15f;
            if (__seedType == WheatSeeds) __result = 9f;
        }
    }
}
