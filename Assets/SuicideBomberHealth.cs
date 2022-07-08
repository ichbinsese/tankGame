using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomberHealth : EnemyHealth
{
    public override void Destroy()
    {
        SuicideBomb bomb = GetComponent<SuicideBomb>();
        foreach (Health health in FindObjectsOfType<Health>())
        {
            if (health == this) continue;
            if (!(Vector2.Distance(health.transform.position, transform.position) <= bomb.range)) continue;
            health.TakeDamage(bomb.fireMode.damage);
            
        }
        Instantiate(GetComponent<EnemyHealth>().deathAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
