using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects;

public class RemoveSpyEffect : CustomFoodEffect
{
    public override string InternalName => "RemoveSpyEffect";

    public override bool Positive() => true;

    public override string Description() => "chance of removing spy trait";

    public override Action<FollowerBrain> Effect => (brain) => brain.RemoveTrait(FollowerTrait.TraitType.Spy);
}