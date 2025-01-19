using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class GainRoyalPooperTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainRoyalPooperTraitEffect";
    
    public override string Description() => "chance of follower of becoming a royal pooper";

    public override Action<FollowerBrain> Effect => (brain) =>  brain.AddTrait(FollowerTrait.TraitType.RoyalPooper, true);
    
}