using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool hurtsEnemys;
    public float speed;
    public int colissionDurability;
    public int damage;

    private int colissionsRemaining;
    

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colissionsRemaining = colissionDurability;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += (Vector2) (speed / 100 * transform.up);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Terrain Layer
        if (collision.collider.gameObject.layer == 6)
        {

            if(colissionsRemaining == 0) Explode();
            transform.up = Vector2.Reflect(transform.up, collision.contacts[0].normal);
            colissionsRemaining--;
        }
        //Bullet and Tank Layer
        else if (collision.collider.gameObject.layer == 8 || collision.collider.gameObject.layer == 7)
        {
            Health health;
            if(!hurtsEnemys && collision.gameObject.TryGetComponent<Enemy>(out _)) Explode();
            if (collision.gameObject.TryGetComponent<Health>(out health)) health.TakeDamage(damage); 
            Explode();
        }



    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
