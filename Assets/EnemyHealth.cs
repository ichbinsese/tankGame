using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject deathAnimation;
    public override void Destroy()
    {
        Instantiate(deathAnimation, transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
