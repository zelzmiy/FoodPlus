using System;
using System.IO;
using FoodPlus.CustomTraits;
using FoodPlus.Items;
using FoodPlus.Items.Ingrediants;
using FoodPlus.Items.Seeds;
using FoodPlus.MealEffects;

namespace FoodPlus;

[BepInPlugin(PluginGuid, PluginName, PluginVer)]
[BepInDependency("io.github.xhayper.COTL_API")]
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "xyz.zelzmiy.FoodPlus";
    public const string PluginName = "FoodPlus";
    public const string PluginVer = "1.0.0";

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
        
        TraitRegistry.RegisterTraits();
        FoodEffectRegistry.RegisterFoodEffects();
        ItemRegistry.RegisterItems();
        
        LogInfo($"Loaded {PluginName}!");
    }

    private void OnDisable()
    {
        Harmony.UnpatchSelf();
        LogInfo($"Unloaded {PluginName}!");
    }

#if DEBUG
    public void Update()
    {
        // debug

        //give self items
        if (Input.GetKeyDown(KeyCode.J))
        {
            Inventory.AddItem(ItemRegistry.Get(nameof(WheatSeeds)), 5);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Inventory.AddItem(ItemRegistry.Get(nameof(Bread)), 25);

            Inventory.AddItem(ItemRegistry.Get(nameof(DeathPepper)), 25);
            Inventory.AddItem(ItemRegistry.Get(nameof(Onion)), 25);
            Inventory.AddItem(ItemRegistry.Get(nameof(Tomato)), 25);
            Inventory.AddItem(ItemRegistry.Get(nameof(Wheat)), 25);

            Inventory.AddItem(ItemRegistry.Get(nameof(IchorSeeds)), 25);
            Inventory.AddItem(ItemRegistry.Get(nameof(OnionSeeds)), 25);
            Inventory.AddItem(ItemRegistry.Get(nameof(TomatoSeeds)), 25);
            Inventory.AddItem(ItemRegistry.Get(nameof(WheatSeeds)), 25);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach (InventoryItem.ITEM_TYPE value in Enum.GetValues(typeof(InventoryItem.ITEM_TYPE)))
            {
                Inventory.SetItemQuantity((int)value, 100);
            }
        }

        //give self rainbow poop for testing
        if (Input.GetKeyDown(KeyCode.F))
        {
            Inventory.AddItem(InventoryItem.ITEM_TYPE.POOP_RAINBOW, 5);
        }
    }
}
#endif