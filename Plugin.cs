using System.IO;
using COTL_API.CustomInventory;
using COTL_API.CustomFollowerCommand;
using System.Reflection;
using System.Linq;
using System;
using FoodPlus.Items;
using FoodPlus.Items.Seeds;
using FoodPlus.Items.Plants;
using UnityEngine.SceneManagement;
using COTL_API.CustomLocalization;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using FoodPlus.Patches;

namespace FoodPlus;

[BepInPlugin(PluginGuid, PluginName, PluginVer)]
[BepInDependency("io.github.xhayper.COTL_API")]
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
	public const string PluginGuid = "xyz.zelzmiy.foodplus";
	public const string PluginName = "FoodPlus";
	public const string PluginVer = "1.0.0";

	internal static ManualLogSource Log;
	internal readonly static Harmony Harmony = new(PluginGuid);

	internal static string PluginPath;

	private void Awake()
	{
		Log = Logger;
		PluginPath = Path.GetDirectoryName(Info.Location);

		string localizationPath = Path.Combine(PluginPath, "Assets", "Localization.language");
		CustomLocalizationManager.LoadLocalization("English", localizationPath);
		ItemRegistery.AddAllItems();
	}

	private void OnEnable()
	{
		Harmony.PatchAll();
		SceneManager.sceneLoaded += OnCultLoaded;
	}

	private void OnDisable()
	{
		Harmony.UnpatchSelf();
		LogInfo($"Unloaded {PluginName}!");
	}

	public void OnCultLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name != "Base Biome 1")
			return;

		GameManager.GetInstance().StartCoroutine(GetOrLoadAsset(FoodRelatedPatches.GetMealObjectPath(InventoryItem.ITEM_TYPE.MEAL_BERRIES), null));
		//CustomCropControllers.IntitalizeControllers();
	}

	public void Update()
	{
		// debug

		//give self items
		if (Input.GetKeyDown(KeyCode.J))
		{
			Inventory.AddItem(ItemRegistery.IchorSeeds, 5);
			Inventory.AddItem(ItemRegistery.LettuceSeeds, 5);
			Inventory.AddItem(ItemRegistery.OnionBulb, 5);
			Inventory.AddItem(ItemRegistery.TomatoSeeds, 5);
			Inventory.AddItem(ItemRegistery.WheatSeeds, 5);

			Inventory.AddItem(ItemRegistery.DeathPepper, 5);
			Inventory.AddItem(ItemRegistery.Lettuce, 5);
			Inventory.AddItem(ItemRegistery.Onion, 5);
			Inventory.AddItem(ItemRegistery.Tomato, 5);
			Inventory.AddItem(ItemRegistery.Wheat, 5);

			Inventory.AddItem(ItemRegistery.Bread, 5);
		}

		if (Input.GetKeyDown(KeyCode.Y))
		{
			InventoryItem.Spawn(InventoryItem.ITEM_TYPE.MEAL_EGG, 3, new Vector3(0,0,0));
		}

		//give self rainbow poop for testing
		if (Input.GetKeyDown(KeyCode.F))
		{
			Inventory.AddItem(InventoryItem.ITEM_TYPE.POOP_RAINBOW, 5);
		}
	}

	// this is just ObjectPool.SpawnIE but worse
	public static IEnumerator<GameObject> GetOrLoadAsset(string path, Action<GameObject> callback)
	{
		if (ObjectPool.instance.loadedAddressables.ContainsKey(path))
		{
			while (ObjectPool.instance.loadedAddressables[path].Result == null)
			{
				yield return null;
			}
			if (ObjectPool.instance.loadedAddressables[path].Status != AsyncOperationStatus.Failed)
			{
				callback?.Invoke(ObjectPool.instance.loadedAddressables[path].Result);
			}
			else
			{
				Debug.Log(("OBJECT POOL, failed addressable: " + path).Colour(Color.red));
			}
		}
		else
		{
			AsyncOperationHandle<GameObject> value = Addressables.LoadAssetAsync<GameObject>(path);
			ObjectPool.instance.loadedAddressables.Add(path, value);
			value.Completed += delegate (AsyncOperationHandle<GameObject> obj)
			{
				ObjectPool.instance.loadedAddressables[path] = obj;
				callback?.Invoke(ObjectPool.instance.loadedAddressables[path].Result);
			};
		}
	}
}