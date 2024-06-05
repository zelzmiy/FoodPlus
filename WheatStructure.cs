using COTL_API.CustomStructures;
using Lamb.UI.BuildMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoodPlus
{
    internal class WheatStructure : CustomStructure
    {
        public override string InternalName => "Wheat_Structure";

        public override Categories StructureCategories => Categories.RESOURCES;

        public override FollowerCategory.Category Category => FollowerCategory.Category.Food;

        public override bool HiddenUntilUnlocked() => true;

        public override Sprite Sprite => TextureHelper.CreateSpriteFromPath(Path.Combine(Plugin.PluginPath, "Assets", "structures", "wheat_structure"));

        public override Vector2Int Bounds => new(1, 1);

    }
}
