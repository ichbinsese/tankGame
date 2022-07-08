using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomb : Weapon
{
    public float triggerDistance;
    public float range;
    public float explodeTime;
    private bool _fused = false;

    public override void Update()
    {
        base.Update();
        if (_cooldown <= 0 && _fused) GetComponent<Health>().Destroy();
    }

    public override void Fire(Vector2 position)
    {
        if (_fused) return;
        if (!(Vector2.Distance(position, transform.position) <= triggerDistance)) return;
        _fused = true;
        _cooldown = explodeTime;

    }

  
}
