using System;

namespace FoodPlus.Utils;

[AttributeUsage(AttributeTargets.Class)]
public class MealToRegister : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class DrinkToRegister : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class ItemToRegister : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class FoodEffectToRegister : Attribute;

public class CropToRegister : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class TraitToRegister : Attribute;
