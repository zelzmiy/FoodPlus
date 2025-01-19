namespace FoodPlus.CustomTraits.Traits;

[HarmonyPatch]
[TraitToRegister]
public class SpiceHaterTrait : CustomTrait
{
    public override string InternalName => "Spice_Hater";

    public override bool Positive => true;
    
    public override TraitFlags TraitFlags => TraitFlags.STARTING_TRAIT | TraitFlags.EXCLUDE_FROM_MATING;
    
    public override string LocalizedTitle() => "Spice Hater";
    
    public override string LocalizedDescription() => "Hates Spicy Food";

    public override Sprite Icon => CreateSprite(TraitsPath, "Spice_Hater.png");
    
}