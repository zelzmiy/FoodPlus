using System;
using System.Collections.Generic;
using System.Linq;
using COTL_API.CustomInventory;
using Lamb.UI.FollowerSelect;

namespace FoodPlus.MealEffects;

public class GainPettableTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainPettableTraitEffect";
    
    public override string Description() => "chance of follower becoming pettable";

    public override Action<FollowerBrain> Effect => (brain) =>  brain.AddTrait(FollowerTrait.TraitType.Pettable, true);
    
}