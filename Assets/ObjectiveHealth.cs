using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHealth : EnemyHealth
{
    public override void Destroy()
    {
        base.Destroy();
        GetComponent<DestroyObjective>().Collect();
    }
}
