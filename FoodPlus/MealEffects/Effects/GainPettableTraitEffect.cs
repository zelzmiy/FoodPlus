using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class GainPettableTraitEffect : CustomFoodEffect
{
    public override string InternalName => "GainPettableTraitEffect";
    
    public override string Description() => "chance of follower becoming pettable";

    public override Action<FollowerBrain> Effect => (brain) =>  brain.AddTrait(FollowerTrait.TraitType.Pettable, true);
    
}