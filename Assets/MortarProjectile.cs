using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarProjectile : Projectile
{
    public GameObject explosionEffect;
    public float maxSize;
    public float rotationSpeed;
    public float blastRadius;

    private Vector2 _targetPoint = Vector2.zero;
    private float _startDistance;
    private Rigidbody2D _rb;
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        _rb.position += (Vector2) (speed / 100 * transform.up);
        CheckPosition();
    }

    private void CheckPosition()
    {
        Vector2 p = (Vector2)transform.position - _targetPoint;
        if (decimal.Round((decimal)p.x, 1) == 0 && decimal.Round((decimal)p.y, 1) == 0) Explode();
    }

    private void Start()
    {
        _startDistance = Vector2.Distance(_targetPoint, new Vector2(transform.position.x, transform.position.y));
        _rb = GetComponent<Rigidbody2D>();
        
    }

    public void Initiate(float rotation, Vector2 target)
    {
        _targetPoint = target;
        transform.eulerAngles = new Vector3(0f, 0f, rotation);

    }


    protected override void Animate()
    {
        float progress =  ( Vector2.Distance(_targetPoint, new Vector2(transform.position.x, transform.position.y)) / _startDistance) * 2 ;
        progress--;
        float size =- (progress * progress) + 1;
        size *= maxSize - 1;
        size += 1;
        transform.localScale = new Vector3(size,size,1);
        Transform t = GetComponentsInChildren<Transform>()[1];
        t.eulerAngles = new Vector3(0, 0, t.eulerAngles.z + rotationSpeed * 10);



    }

    public override void Explode()
    {
        foreach (Health health in FindObjectsOfType<Health>())
        {
            if (Vector2.Distance(_targetPoint, new Vector2(health.transform.position.x, health.transform.position.y)) <
                blastRadius)
            {
                health.TakeDamage(damage);
            }
        }
        
        if(explosionEffect != null) Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
    
}
