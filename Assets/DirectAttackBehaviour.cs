using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectAttackBehaviour : EnemyAttackBehaviour
{
    public override void OnSightLost()
    {
        base.OnSightLost();
        weapon.Aim(transform.up);
    }

    public override void FollowingBehaviour()
    {
        base.FollowingBehaviour();
        weapon.Fire(lastPlayerPos);
    }
    
}
