using System;
using COTL_API.CustomInventory;
using FoodPlus.CustomTraits;
using FoodPlus.CustomTraits.Traits;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class GainNeonPooperTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainNeonPooperTraitEffect";
    
    public override string Description() => "chance of follower becoming a Neon Pooper.";

    public override Action<FollowerBrain> Effect => (brain) =>  
        brain.AddTrait(TraitRegistry.Get(nameof(NeonPooperTrait)), true);
    
}