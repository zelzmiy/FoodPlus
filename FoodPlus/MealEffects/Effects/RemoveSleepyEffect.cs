using System;
using COTL_API.CustomInventory;
using Random = System.Random;

namespace FoodPlus.MealEffects;

public class RemoveSleepyEffect : CustomFoodEffect
{
    public override string InternalName => "RemoveSleepyEffect";

    public override bool Positive() => true;

    public override string Description() => "of removing sleepy";

    public override Action<FollowerBrain> Effect => (brain) =>
    {
        brain.Stats.Exhaustion = 1f;
    };

}