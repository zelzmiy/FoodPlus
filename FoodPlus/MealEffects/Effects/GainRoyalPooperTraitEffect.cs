using System;
using System.Collections.Generic;
using System.Linq;
using COTL_API.CustomInventory;
using Lamb.UI.FollowerSelect;

namespace FoodPlus.MealEffects;

public class GainRoyalPooperTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainRoyalPooperTraitEffect";
    
    public override string Description() => "chance of follower of becoming a royal pooper";

    public override Action<FollowerBrain> Effect => (brain) =>  brain.AddTrait(FollowerTrait.TraitType.RoyalPooper, true);
    
}