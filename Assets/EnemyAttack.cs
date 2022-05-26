using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    public Transform bulletSpawner;
    
    public FireMode fireMode;
    private float cooldown;

    protected void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;
    }

    public virtual void Fire()
    {
        if (cooldown > 0) return;
        foreach (Collider2D collider in FindObjectsOfType<Collider2D>())
        {

            if (collider.gameObject.layer == 6)
            {
                if (collider.OverlapPoint(bulletSpawner.position)) return;
            }
        }

        GameObject bullet = Instantiate(fireMode.projectile, bulletSpawner.position, bulletSpawner.rotation);
        bullet.GetComponent<Bullet>().colissionDurability = fireMode.durability;
        SetCooldown();
        
    }

    public void SetCooldown()
    {
        cooldown = 1 / fireMode.fireSpeed;
    }

    public void SetCooldown(float t)
    {
        cooldown = t;
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
