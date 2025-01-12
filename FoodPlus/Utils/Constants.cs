namespace FoodPlus;

public static class Constants
{
    public static string IngredientsPath => Path.Combine(Plugin.PluginPath, "Assets", "Ingredients");
    public static string CropsPath => Path.Combine(Plugin.PluginPath, "Assets", "Crops");
    public static string MealsPath => Path.Combine(Plugin.PluginPath, "Assets", "Meals");
    public static string SeedsPath => Path.Combine(Plugin.PluginPath, "Assets", "Seeds");

    public static Sprite CreateSprite(params string[] path)
    {
        return TextureHelper.CreateSpriteFromPath(Path.Combine(path));
    }
}

