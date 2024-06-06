using COTL_API.CustomStructures;
using COTL_API.Prefabs;
using FoodPlus.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoodPlus
{
    internal class CustomCropControllers
    {

        public static CropController IchorCropController = new()
        {
            SeedType = ItemRegistery.IchorSeeds,
            CropStates = IchorGameObjects
        };

        public static CropController LettuceCropController = new()
        {
            SeedType = ItemRegistery.LettuceSeeds,
            CropStates = LettuceGameObjects
        };
        public static CropController OnionCropController = new()
        {
            SeedType = ItemRegistery.OnionBulb,
            CropStates = OnionGameObjects
        };
        public static CropController TomatoCropController = new()
        {
            SeedType = ItemRegistery.TomatoSeeds,
            CropStates = TomatoGameObjects
        };
        public static CropController WheatCropController = new()
        {
            SeedType = ItemRegistery.Wheat,
            CropStates = WheatGameObjects
            
        };

        private static List<GameObject> IchorGameObjects = new(4);
        private static List<GameObject> LettuceGameObjects = new(4);
        private static List<GameObject> OnionGameObjects = new(4);
        private static List<GameObject> TomatoGameObjects = new(4);
        // if hell exists, this is what it looks lke
        public static List<GameObject> WheatGameObjects =
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
}
