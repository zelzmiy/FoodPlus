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

		LogInfo("LOADING CULT SCENE!!! TIME FOR NRE!!!");
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
			foreach (InventoryItem.ITEM_TYPE item in Enum.GetValues(typeof(InventoryItem.ITEM_TYPE)))
			{
				Inventory.SetItemQuantity((int)item, 50);
			}
		}

		//give self rainbow poop for testing
		if (Input.GetKeyDown(KeyCode.F))
		{
			Inventory.AddItem(InventoryItem.ITEM_TYPE.POOP_RAINBOW, 5);
		}
	}
}