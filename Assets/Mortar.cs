using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : Weapon
{
    public Transform visLight;
    public float saveDistance;
    public Transform rotator;
    public override void Aim(Vector2 position)
    {
        Vector2 pointPosVector = position - (Vector2)transform.position;
        float rotation = Mathf.Acos(Vector2.Dot(pointPosVector, Vector2.up) / pointPosVector.magnitude); //omg Mathematik Untericht
        rotation *= Mathf.Rad2Deg;
        if (pointPosVector.x > 0) rotation = -rotation;
        rotator.eulerAngles = new Vector3(0f, 0f, rotation);
    }
    public override void Fire(Vector2 position)
    {
        if (_cooldown > 0) return;
        if(Vector2.Distance(position, new Vector2(transform.position.x,transform.position.y)) < saveDistance ) return;
        Aim(position);
        GameObject projectile = Instantiate(fireMode.projectile, transform.position,Quaternion.identity);
        projectile.GetComponent<MortarProjectile>().Initiate(rotator.eulerAngles.z,position);
        projectile.GetComponent<Projectile>().hurtsEnemys = fireMode.hurtsEnemy;
        SetCooldown();
    }

    public override void Visualize()
    {
        visLight.position =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
