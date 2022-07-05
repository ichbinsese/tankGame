using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : Weapon
{
    public Transform visLight;
    public float saveDistance;
    public override void Fire(Vector2 position)
    {
        if (_cooldown > 0) return;
        if(Vector2.Distance(position, new Vector2(transform.position.x,transform.position.y)) < saveDistance ) return;
        Vector2 pointPosVector = position - (Vector2)transform.position;
        float rotation = Mathf.Acos(Vector2.Dot(pointPosVector, Vector2.up) / pointPosVector.magnitude); //omg Mathematik Untericht
        rotation *= Mathf.Rad2Deg;
        if (pointPosVector.x > 0) rotation = -rotation;
        SetCooldown();
        GameObject projectile = Instantiate(fireMode.projectile, transform.position,Quaternion.identity);
        projectile.GetComponent<MortarProjectile>().Initiate(rotation,position);
        projectile.GetComponent<Projectile>().hurtsEnemys = fireMode.hurtsEnemy;
    }

    public override void Visualize()
    {
        visLight.position =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
