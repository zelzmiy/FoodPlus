using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class RemoveTerrifiedEffect : CustomFoodEffect
{
    public override string InternalName => "RemoveTerrifiedEffect";

    public override bool Positive() => true;

    public override string Description() => "chance of removing terrified trait";

    public override Action<FollowerBrain> Effect => (brain) => brain.RemoveTrait(FollowerTrait.TraitType.Terrified);
}