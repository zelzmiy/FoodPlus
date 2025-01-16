using System;
using System.Linq;
using COTL_API.CustomInventory;
using FoodPlus.Items;
using FoodPlus.Items.Ingrediants;
using FoodPlus.Items.Seeds;
using Random = UnityEngine.Random;

namespace FoodPlus.Patches;

[HarmonyPatch]
public static class SeedsToBossChestPatches
{
    [HarmonyPatch(typeof(Interaction_Chest), nameof(Interaction_Chest.RevealBossReward))]
    [HarmonyPostfix]
    private static void Interaction_Chest_RevealBossReward(Interaction_Chest __instance)
    {
        foreach (var temp in __instance.Enemies 
                     .Select(enemy => enemy.GetComponent<UnitObject>())
                     .Where(temp => temp.isBoss))
        {
            switch (temp.enemyType)
            {
                case Enemy.WormBoss:
                    SpawnBossSeeds(ItemRegistry.Get(nameof(GrassSeeds)));
                    break;
                case Enemy.FrogBoss:
                    SpawnBossSeeds(ItemRegistry.Get(nameof(OnionSeeds)));
                    break;
                case Enemy.JellyBoss:
                    SpawnBossSeeds(ItemRegistry.Get(nameof(TomatoSeeds)));
                    break;
                case Enemy.SpiderBoss:
                    SpawnBossSeeds(ItemRegistry.Get(nameof(WheatSeeds)));
                    break;
                default:
                    throw new ArgumentException("isBoss but is not any of the enemy types to be boss? huh.");
            }
        }

        return;

        void SpawnBossSeeds(in InventoryItem.ITEM_TYPE itemType)
        {
            var item = CustomItemManager.CustomItemList[itemType];
            InventoryItem.Spawn(itemType,
                Random.Range(item.DungeonChestMinAmount, item.DungeonChestMaxAmount + 1),
                __instance.transform.position);
        }
    }
    
}