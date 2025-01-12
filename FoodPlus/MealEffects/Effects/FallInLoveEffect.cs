using System;
using System.Collections.Generic;
using System.Linq;
using COTL_API.CustomInventory;
using Lamb.UI.FollowerSelect;

namespace FoodPlus.MealEffects;

public class FallInLoveEffect : CustomFoodEffect
{
    public override string InternalName => "FallInLoveEffect";
    
    public override string Description() => "chance of follower falling in love with a random follower";

    public override Action<FollowerBrain> Effect => (brain) =>
    {
        
        List<Follower> followers = [];
        followers.AddRange(Follower.Followers.Where(cultist => !DataManager.Instance.Followers_Recruit.Contains(cultist.Brain._directInfoAccess) && cultist.Brain.Info.ID != brain.Info.ID).Where(cultist => FollowerManager.GetFollowerAvailabilityStatus(cultist.Brain, false) == FollowerSelectEntry.Status.Available));
        var partner = followers.RandomElement();
        var ship = brain.Info.GetOrCreateRelationship(partner.Brain.Info.ID);
        ship.CurrentRelationshipState = IDAndRelationship.RelationshipState.Lovers;
        ship.Relationship = 10;
        NotificationCentre.Instance.PlayGenericNotification($"{brain.Info.Name} has fallen in love with {partner.Brain.Info.Name}", NotificationBase.Flair.Positive);
    };
    
}