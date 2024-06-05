using System.IO;
using COTL_API.CustomInventory;
using COTL_API.CustomFollowerCommand;
using System.Reflection;
using System.Linq;
using System;
using FoodPlus.Items;
using FoodPlus.Items.Seeds;
using FoodPlus.Items.Plants;

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
        public static InventoryItem.ITEM_TYPE IchorSeeds;
        public static InventoryItem.ITEM_TYPE LettuceSeeds;
        public static InventoryItem.ITEM_TYPE OnionBulb;
        public static InventoryItem.ITEM_TYPE TomatoSeeds;
        public static InventoryItem.ITEM_TYPE WheatSeeds;

        /* Fruit */
        public static InventoryItem.ITEM_TYPE DeathPepper;
        public static InventoryItem.ITEM_TYPE Lettuce;
        public static InventoryItem.ITEM_TYPE Onion;
        public static InventoryItem.ITEM_TYPE Tomato;
        public static InventoryItem.ITEM_TYPE Wheat;

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

            IchorSeeds   = CustomItemManager.Add(new IchorSeeds() );
            LettuceSeeds = CustomItemManager.Add(new TomatoSeeds());
            OnionBulb    = CustomItemManager.Add(new TomatoSeeds());
            TomatoSeeds  = CustomItemManager.Add(new TomatoSeeds());
            WheatSeeds   = CustomItemManager.Add(new WheatSeeds() );

            DeathPepper  = CustomItemManager.Add(new DeathPepper());
            Lettuce      = CustomItemManager.Add(new Lettuce()    );
            Onion        = CustomItemManager.Add(new Onion()      );
            Tomato       = CustomItemManager.Add(new Tomato()     );
            Wheat        = CustomItemManager.Add(new Wheat()      );

            Bread        = CustomItemManager.Add(new Bread()      );
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
                Inventory.AddItem(IchorSeeds,   5);
                Inventory.AddItem(LettuceSeeds, 5);
                Inventory.AddItem(OnionBulb,    5);
                Inventory.AddItem(TomatoSeeds,  5);
                Inventory.AddItem(WheatSeeds,   5);

                Inventory.AddItem(DeathPepper,  5);
                Inventory.AddItem(Lettuce,      5);
                Inventory.AddItem(Onion,        5);
                Inventory.AddItem(Tomato,       5);
                Inventory.AddItem(Wheat,        5);

                Inventory.AddItem(Bread,        5);
            }
        }
    }
}