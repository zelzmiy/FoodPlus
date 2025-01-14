using System.Collections.Generic;

namespace FoodPlus.CustomTraits.Traits;

[HarmonyPatch]
public class SpiceHaterTrait : CustomTrait
{
    public override string InternalName => "Spice_Lover";

    public override bool Positive => true;
    
    public override TraitFlags TraitFlags => TraitFlags.StartingTrait | TraitFlags.ExcludeFromMating;
    
    public override string LocalizedTitle() => "Spice Hater";
    
    public override string LocalizedDescription() => "Hates Spicy Food";

    public override Sprite Icon => CreateSprite(TraitsPath, "Spice_Hater.png");
    
}