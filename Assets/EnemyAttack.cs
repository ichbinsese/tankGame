using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    public Transform bulletSpawner;
    
    public FireMode fireMode;
    private float _cooldown;

    protected void Update()
    {
        if (_cooldown > 0) _cooldown -= Time.deltaTime;
    }

    public virtual void Fire()
    {
        if (_cooldown > 0) return;
        foreach (Collider2D collider in FindObjectsOfType<Collider2D>())
        {

            if (collider.gameObject.layer == 6)
            {
                if (collider.OverlapPoint(bulletSpawner.position)) return;
            }
        }

        GameObject bullet = Instantiate(fireMode.projectile, bulletSpawner.position, bulletSpawner.rotation);
        bullet.GetComponent<Rocket>().colissionDurability = fireMode.durability;
        bullet.GetComponent<Rocket>().hurtsEnemys = false;
        SetCooldown();
        
    }

    public void SetCooldown()
    {
        _cooldown = 1 / fireMode.fireSpeed;
    }

    public void SetCooldown(float t)
    {
        _cooldown = t;
    }

    public float GetCooldown()
    {
        return _cooldown;
    }
}
