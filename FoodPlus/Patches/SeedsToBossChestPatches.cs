using System;
using System.Collections;
using COTL_API.CustomInventory;
using FoodPlus.Items;
using FoodPlus.Items.Seeds;
using Random = UnityEngine.Random;

namespace FoodPlus.Patches;

[HarmonyPatch]
public static class SeedsToBossChestPatches
{
    [HarmonyPatch(typeof(Interaction_Chest), nameof(Interaction_Chest.GiveBossReward))]
    [HarmonyPostfix]
    private static void Interaction_Chest_RevealBossReward(Interaction_Chest __instance)
    {
        if (!__instance.BigBossChest) return;
        var enemyType = __instance.transform.parent.GetComponent<PlayerHealthTracker>().enemyType;

        var position = __instance.transform.position;
        switch (enemyType)
        {
            case Enemy.WormBoss:
                Plugin.Instance.StartCoroutine(SpawnBossSeeds(ItemRegistry.Get(nameof(GrassSeeds)), position));
                break;
            case Enemy.FrogBoss:
                Plugin.Instance.StartCoroutine(SpawnBossSeeds(ItemRegistry.Get(nameof(OnionSeeds)), position));
                break;
            case Enemy.JellyBoss:
                Plugin.Instance.StartCoroutine(SpawnBossSeeds(ItemRegistry.Get(nameof(TomatoSeeds)), position));
                break;
            case Enemy.SpiderBoss:
                Plugin.Instance.StartCoroutine(SpawnBossSeeds(ItemRegistry.Get(nameof(WheatSeeds)), position));
                break;
            default:
                throw new ArgumentException("BigBossChest but is not any of the enemy types to be boss? huh.");
        }
        
    }

    private static IEnumerator SpawnBossSeeds(InventoryItem.ITEM_TYPE itemType, Vector3 position)
    {
        var item = CustomItemManager.CustomItemList[itemType];
        for (var i = 0; i < Random.Range(item.DungeonChestMinAmount, item.DungeonChestMaxAmount + 1); i++)
        {
            var pickUp = InventoryItem.Spawn(itemType, 1, position);
            pickUp.SetInitialSpeedAndDiraction(4f + Random.Range(-0.5f, 1f), 270 + Random.Range(-90, 90));
            pickUp.MagnetDistance = 3f;
            pickUp.CanStopFollowingPlayer = false;
            yield return new WaitForSeconds(0.01f);
        }
    }
}