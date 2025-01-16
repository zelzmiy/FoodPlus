using System.Collections.Generic;

namespace FoodPlus.CustomTraits.Traits;

[HarmonyPatch]
public class SpiceLoverTrait : CustomTrait
{
    public override string InternalName => "Spice_Lover";

    public override bool Positive => true;

    public override List<FollowerTrait.TraitType> ExclusiveTraits =>
    [
        TraitRegistry.Get(nameof(SpiceHaterTrait))
    ];

    public override TraitFlags TraitFlags => TraitFlags.STARTING_TRAIT | TraitFlags.EXCLUDE_FROM_MATING;
    
    public override string LocalizedTitle() => "Spice Lover";
    
    public override string LocalizedDescription() => "Loves Spicy Food.";

    public override Sprite Icon => CreateSprite(TraitsPath, "Spice_Lover.png");
}