using COTL_API.CustomStructures;
using COTL_API.Prefabs;
using FoodPlus.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoodPlus;

internal class CustomCropControllers
{

	public static void IntitalizeControllers()
	{
	GameObject tempObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
	tempObject.SetActive(false);

	WheatCropController = tempObject.AddComponent<CropController>();
	WheatCropController.SeedType = ItemRegistery.WheatSeeds;
	WheatCropController.CropStates = WheatGameObjects;
	WheatCropController.BumperCropObject = tempObject;
	WheatCropController.GrowRateIcons = tempObject;
	}

	public static CropController WheatCropController;

	// if hell exists, this is what it looks lke
	private static List<GameObject> WheatGameObjects =
	[
		CustomPrefabManager.CreatePlacementObjectFor(new PlantStructure("Wheat_0", TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "structures", "wheat_0.png")))),
		CustomPrefabManager.CreatePlacementObjectFor(new PlantStructure("Wheat_1", TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "structures", "wheat_1.png")))),
		CustomPrefabManager.CreatePlacementObjectFor(new PlantStructure("Wheat_2", TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "structures", "wheat_2.png")))),
		CustomPrefabManager.CreatePlacementObjectFor(new PlantStructure("Wheat_3", TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "structures", "wheat_3.png"))))
	];

}

internal sealed class PlantStructure : CustomStructure
{
	public override string InternalName { get; }
	public override Vector2Int Bounds => new(1, 1);
	public override Sprite Sprite { get; }

	public PlantStructure(string name, Sprite sprite)
	{
	InternalName = name;
	Sprite = sprite;
	}
}
