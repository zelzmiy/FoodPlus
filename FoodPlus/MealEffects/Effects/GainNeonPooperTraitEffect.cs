using System;
using System.Collections.Generic;
using System.Linq;
using COTL_API.CustomInventory;
using FoodPlus.CustomTraits;
using FoodPlus.CustomTraits.Traits;
using Lamb.UI.FollowerSelect;

namespace FoodPlus.MealEffects;

public class GainNeonPooperTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainNeonPooperTraitEffect";
    
    public override string Description() => "chance of follower becoming a Neon Pooper.";

    public override Action<FollowerBrain> Effect => (brain) =>  
        brain.AddTrait(TraitRegistry.Get(nameof(NeonPooperTrait)), true);
    
}