using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodPlus.Utils;

[HarmonyPatch]
public class DelayedActionManager
{
    private static readonly Dictionary<int, List<DelayedAction<Follower>>> s_followerTimers = [];

    public static void CreateDelayedAction(int hoursToEffect, Follower follower, Action<Follower> action)
    {
        s_followerTimers.AddOrCreate(follower.Brain.Info.ID, new DelayedAction<Follower>(hoursToEffect, action));
    }

    [HarmonyPatch(typeof(TimeManager),nameof(TimeManager.CurrentHour), methodType:MethodType.Setter)]
    [HarmonyPostfix]    
    private static void TimeManager_get_CurrentHour(ref int value) // crime or cringe
    {
        if (TimeManager.CurrentHour == value) return;

        foreach (var timer in s_followerTimers)
        {
            foreach (var effect in timer.Value.ToList())
            {
                if (value - effect.StartTime <= effect.HoursToEffect) continue;

                var follower = FollowerManager.FindFollowerByID(timer.Key);
                effect.Invoke(follower);
                timer.Value.Remove(effect);
                
                if (timer.Value.Count == 0)
                {
                    s_followerTimers.Remove(follower.Brain.Info.ID);
                }
            }
        }
    }
    
    private class DelayedAction<T>(int hoursToEffect, Action<T> action)
    {
        public readonly int HoursToEffect = hoursToEffect;
        public readonly int StartTime = TimeManager.CurrentHour;

        public void Invoke(T item)
        {
            action.Invoke(item);
        }

    }
}
