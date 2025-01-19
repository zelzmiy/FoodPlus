using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class GainSinHalf : CustomFoodEffect
{
    public override string InternalName => "GainSinHalfEffect";

    public override bool Positive() => true;

    public override string Description() => "chance of gaining sin";

    public override Action<FollowerBrain> Effect => (brain) =>
    {
        brain.AddPleasure(FollowerBrain.PleasureActions.Testing_Half);
    };
}

[FoodEffectToRegister]
public class GainSinFull : CustomFoodEffect
{
    public override string InternalName => "GainSinFullEffect";

    public override bool Positive() => true;

    public override string Description() => "chance of gaining sin";

    public override Action<FollowerBrain> Effect => (brain) =>
    {
        brain.AddPleasure(FollowerBrain.PleasureActions.Testing);
    };
}