using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public FireMode fireMode;
    protected float _cooldown;


    public virtual void Update()
    {
        _cooldown -= Time.deltaTime;
    }

    public virtual void Fire(Vector2 position)
    {
        
    }

    public virtual void Aim(Vector2 position)
    {
        Visualize();
    }

    public virtual void SetCooldown()
    {
        _cooldown = 1 / fireMode.fireSpeed;
    }

    public virtual void Visualize()
    {
        
    }

}
