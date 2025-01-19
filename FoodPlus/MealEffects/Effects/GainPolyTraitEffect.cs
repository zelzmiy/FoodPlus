using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class GainPolyTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainPolyTraitEffect";
    
    public override string Description() => "chance of follower becoming polyamorous.";

    public override Action<FollowerBrain> Effect => (brain) =>  brain.AddTrait(FollowerTrait.TraitType.Polyamory, true);
    
}