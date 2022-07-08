using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSight : EnemySight
{
    public float range;
    public override bool CheckSight()
    {
        return Vector2.Distance(transform.position, GameManager.player.transform.position) <= range;
    }
}
