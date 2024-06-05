using System.IO;
using COTL_API.CustomInventory;
using COTL_API.CustomFollowerCommand;
using System.Reflection;
using System.Linq;
using System;
using FoodPlus.Items;

namespace FoodPlus
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [BepInDependency("io.github.xhayper.COTL_API")]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "xyz.zelzmiy.foodplus";
        public const string PluginName = "FoodPlus";
        public const string PluginVer = "1.0.0";

        /* Seeds */
        public static InventoryItem.ITEM_TYPE WheatSeeds;
        public static InventoryItem.ITEM_TYPE TomatoSeeds;

        /* Fruit */
        public static InventoryItem.ITEM_TYPE Wheat;
        public static InventoryItem.ITEM_TYPE Tomato;

        /* processed/cooked*/
        public static InventoryItem.ITEM_TYPE Bread;

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        private void Awake()
        {
            Log = Logger;
            PluginPath = Path.GetDirectoryName(Info.Location);
        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            WheatSeeds = CustomItemManager.Add(new WheatSeeds());
            Bread = CustomItemManager.Add(new TomatoSeeds());
            Wheat = CustomItemManager.Add(new Wheat());
            Bread = CustomItemManager.Add(new Tomato());
            Bread = CustomItemManager.Add(new Bread());
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            LogInfo($"Unloaded {PluginName}!");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Inventory.AddItem(WheatSeeds, 5);
                Inventory.AddItem(TomatoSeeds, 5);
                Inventory.AddItem(Wheat, 5);
                Inventory.AddItem(Tomato, 5);
                Inventory.AddItem(Bread, 5);
            }
        }
    }
}