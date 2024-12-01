using System.IO;

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
        LogInfo($"Loaded {PluginName}!");
    }

    private void OnDisable()
    {
        Harmony.UnpatchSelf();
        LogInfo($"Unloaded {PluginName}!");
    }
}