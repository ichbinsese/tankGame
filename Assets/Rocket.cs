using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Rocket : Projectile
{
    public GameObject explosionEffect;
    public GameObject wallHitEffect;
    public int colissionDurability;
    private int _colissionsRemaining;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _colissionsRemaining = colissionDurability;
    }
    
     protected override void FixedUpdate()
    {
        _rb.position += (Vector2) (speed / 100 * transform.up);
    }

    public override void OnCollisionTerrain(Collision2D collision )
    {
        if (_colissionsRemaining == 0) Explode();
        else Instantiate(wallHitEffect, transform.position, quaternion.identity);
        transform.up = Vector2.Reflect(transform.up, collision.contacts[0].normal);
        _colissionsRemaining--;
    }

    public override void OnCollisionTank(Collision2D collision )
    {
        Health health;
        if (!hurtsEnemys && collision.gameObject.TryGetComponent<EnemyHealth>(out _))
        {
            Explode();
            return;
                
        }
        if (collision.gameObject.TryGetComponent<Health>(out health)) health.TakeDamage(damage); 
        Explode();
    }

    public override void OnCollisionProjectile(Collision2D collision )
    {
        Explode();
    }
    

    public override void Explode()
    {
       if(explosionEffect != null) Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
