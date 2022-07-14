using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : Weapon
{
    public Transform bulletSpawner;
    public Transform rotator;
    
    //Richtet die Kanone auf einen Ort aus
    public override void Aim(Vector2 position)
    {
        //Vektor zwischen Position und Ziel
        Vector2 pointPosVector = position - (Vector2)transform.position;
        //Berechnet den Winkel des Geschützes (in Radians) 
        float rotation = Mathf.Acos(Vector2.Dot(pointPosVector, Vector2.up) / pointPosVector.magnitude); 
        //Rechnet Radians in Grad um
        rotation *= Mathf.Rad2Deg;
        //Wenn X wert des Vektors negativ ist wird rotation umgedreht (da dot produkt immer den Kleineren Winkel berechnet)
        if (pointPosVector.x > 0) rotation = -rotation; 
        //Setzt den Rotationspunkt zur richtifen Rotation
        rotator.eulerAngles = new Vector3(0f, 0f, rotation);
        
    }

    public override void Fire(Vector2 position)
    {
        //Zielt auf den Richtigen Punkt
        Aim(position);
        //Wenn der Cooldown noch nicht abgelaufen ist abbrechen
        if (_cooldown > 0) return;
        //Hölt Spieler / Gegner davon ab in einer Wand zu schießen
        foreach (Collider2D collider in FindObjectsOfType<Collider2D>())
        {
            if (collider.gameObject.layer != 6) continue;
            if (collider.OverlapPoint(bulletSpawner.position)) return;
        }
        //Spawnt das Geschoss
        GameObject bullet = Instantiate(fireMode.projectile, bulletSpawner.position, bulletSpawner.rotation);
        //Setzt die Werte des Geschosses
        bullet.GetComponent<Rocket>().colissionDurability = fireMode.durability;
        bullet.GetComponent<Rocket>().hurtsEnemys = fireMode.hurtsEnemy;
        //Setzt den Cooldown
        SetCooldown();
    }
}
