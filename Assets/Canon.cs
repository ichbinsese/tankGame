using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : Weapon
{
    public Transform bulletSpawner;
    public Transform rotator;
    public override void Aim(Vector2 position)
    {
        Vector2 pointPosVector = position - (Vector2)transform.position;
        float rotation = Mathf.Acos(Vector2.Dot(pointPosVector, Vector2.up) / pointPosVector.magnitude); //omg Mathematik Untericht
        rotation *= Mathf.Rad2Deg;
        if (pointPosVector.x > 0) rotation = -rotation; //omg das macht das es funktiniert
        rotator.eulerAngles = new Vector3(0f, 0f, rotation);
        
    }

    public override void Fire(Vector2 position)
    {
        Aim(position);
        if (_cooldown > 0) return;
        foreach (Collider2D collider in FindObjectsOfType<Collider2D>())
        {

            if (collider.gameObject.layer == 6)
            {
                if (collider.OverlapPoint(bulletSpawner.position)) return;
            }
        }

        GameObject bullet = Instantiate(fireMode.projectile, bulletSpawner.position, bulletSpawner.rotation);
        bullet.GetComponent<Rocket>().colissionDurability = fireMode.durability;
        bullet.GetComponent<Rocket>().hurtsEnemys = false;
        SetCooldown();
    }
}
