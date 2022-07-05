using System;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public bool hurtsEnemys;
    public float speed;
    public int damage;
    public virtual void OnCollisionProjectile(Collision2D collision )
    {
        
    }
    
    public virtual void OnCollisionTank(Collision2D collision )
    {
        
    }

    public virtual void OnCollisionTerrain(Collision2D collision )
    {
        
    }

    public virtual void Explode()
    {
        
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.gameObject.layer)
        {
            case 6:
                OnCollisionTerrain(collision);
                break;
            case 8 or 9:
                OnCollisionProjectile(collision);
                break;
            case 7:
                OnCollisionTank(collision);
                break;
        }
    }
}
