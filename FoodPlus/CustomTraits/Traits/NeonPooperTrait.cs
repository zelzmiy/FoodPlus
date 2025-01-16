using System.Collections.Generic;

namespace FoodPlus.CustomTraits.Traits;

[HarmonyPatch]
public class NeonPooperTrait : CustomTrait
     {
         public override string InternalName => "Neon_Pooper";
     
         public override bool Positive => true;
     
         public override List<FollowerTrait.TraitType> ExclusiveTraits =>
         [
             FollowerTrait.TraitType.RoyalPooper
         ];
         public override TraitFlags TraitFlags => TraitFlags.RARE_STARTING_TRAIT;
         
         public override string LocalizedTitle() => "Neon Pooper";
         
         public override string LocalizedDescription() => "All poops are rainbow.";
     
         public override Sprite Icon => CreateSprite(TraitsPath, "Neon_Pooper.png");
     
         [HarmonyPatch(typeof(FollowerBrain), nameof(FollowerBrain.GetPoopType))]
         [HarmonyPrefix]
         private static bool FollowerBrain_GetPoopType(ref FollowerBrain __instance, ref StructureBrain.TYPES __result)
         {
             if (!__instance.Info.Traits.Contains(TraitRegistry.Get(nameof(NeonPooperTrait)))) return true;
             
             __result = StructureBrain.TYPES.POOP_RAINBOW;
             DataManager.Instance.DaySinceLastSpecialPoop = TimeManager.CurrentDay;
             return false;
     
         }
}