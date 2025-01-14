using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects;

public class InjureMouthEffect : CustomFoodEffect
{
    public override string InternalName => "InjureMouthEffect";

    public override bool Positive() => false;

    public override string Description() => "chance of injuring follower";

    public override Action<FollowerBrain> Effect => (brain) => brain.ApplyCurseState(Thought.Injured, force: true);
    
}