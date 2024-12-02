using System.IO;

namespace FoodPlus.Helpers;

public static class CropHelper
{
    public static Sprite MakeCropSprite(string spriteName)
    {
        return TextureHelper.CreateSpriteFromPath(Path.Combine(
            Plugin.PluginPath, "Assets", "Crops", spriteName, ".png"));
    }
}