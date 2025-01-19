using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class SpeedUpEffect : CustomFoodEffect
{
    
    private const float SpeedMultiplier = 5f;
    
    private float _currentSpeedMultiplier = 1f;
    
    public override string InternalName => "SpeedUpEffect";

    public override bool Positive() => true;

    public override string Description() => "of making follower faster for <color=yellow>1</color> day.";

    public override Action<FollowerBrain> Effect => (brain) =>
    {
        var follower = FollowerManager.FindFollowerByID(brain.Info.ID);
        _currentSpeedMultiplier *= SpeedMultiplier;
        DelayedActionManager.CreateDelayedAction(2, follower, follower1 =>
        {
            _currentSpeedMultiplier /= SpeedMultiplier;
        });
    };

}