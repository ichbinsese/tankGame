using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomberHealth : EnemyHealth
{
    private List<Health> _tanksCalledDestroyOn = new List<Health>();

    public override void Destroy()
    {
        SuicideBomb bomb = GetComponent<SuicideBomb>();
        
        foreach (Health health in FindObjectsOfType<Health>())
        {
            if (health != this)
            {
                if (!_tanksCalledDestroyOn.Contains(health))
                {
                    if (Vector2.Distance(health.transform.position, transform.position) <= bomb.range)
                    {
                        _tanksCalledDestroyOn.Add(health);
                        health.TakeDamage(bomb.fireMode.damage);
                    }
                }
                
            }
        }
        FindObjectOfType<BreakableWall>().DestroyPart(transform.position, Mathf.RoundToInt(bomb.range -1 ));
        Instantiate(deathAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
