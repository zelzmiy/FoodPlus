using System;
using COTL_API.CustomInventory;

namespace FoodPlus.MealEffects.Effects;
[FoodEffectToRegister]
public class ShuffleColorsEffect : CustomFoodEffect
{
    public override string InternalName => "ShuffleColorsEffect";

    public override bool Positive() => false;

    public override string Description() => "of doing ???";

    public override Action<FollowerBrain> Effect => (brain) =>
    {
        brain.Info.SkinColour = UnityEngine.Random.Range(0,  WorshipperData.Instance.GlobalColourList.Count);
    };

}