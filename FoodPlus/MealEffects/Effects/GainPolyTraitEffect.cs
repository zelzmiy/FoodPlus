using System;
using System.Collections.Generic;
using System.Linq;
using COTL_API.CustomInventory;
using Lamb.UI.FollowerSelect;

namespace FoodPlus.MealEffects;

public class GainPolyTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainPolyTraitEffect";
    
    public override string Description() => "chance of follower becoming polyamorous.";

    public override Action<FollowerBrain> Effect => (brain) =>  brain.AddTrait(FollowerTrait.TraitType.Polyamory, true);
    
}