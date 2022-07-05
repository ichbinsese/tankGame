using System;
using System.Collections.Generic;
using UnityEngine;


public class RocketLauncher : Weapon
{
    public Transform bulletSpawner;
    public Transform rotator;
    public LineRenderer predictionLine;
    private List<Vector3> _points = new List<Vector3>();



    public override void Fire(Vector2 position)
    {
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
        _cooldown = 1 / fireMode.fireSpeed;

    }

    public override void Aim(Vector2 position)
    {
        base.Aim(position);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosVector = mousePos - (Vector2) transform.position;
        float rotation = Mathf.Acos(Vector2.Dot(mousePosVector, Vector2.up) / mousePosVector.magnitude); //omg Mathematik Untericht
        rotation *= Mathf.Rad2Deg;
        if (mousePosVector.x > 0)rotation = -rotation; //omg das macht das es funktiniert
        rotator.eulerAngles = new Vector3(0f, 0f, rotation);
    }

    public override void Visualize()
    {
        CalculateDirection();
        predictionLine.positionCount = _points.Count;
        predictionLine.SetPositions(_points.ToArray());
    }

    private void CalculateDirection()
    {
        _points.Clear();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 startDirection = mousePosition - (Vector2)bulletSpawner.position;

        Vector2 direction = startDirection;
        Vector2 point = bulletSpawner.position;

        _points.Add(point);

        for (int i = 0; i < fireMode.projectile.GetComponent<Rocket>().colissionDurability + 1; i++)
        {
            RaycastHit2D raycast = Physics2D.Raycast(point, direction);

            point = raycast.point;
            direction = Vector2.Reflect(direction, raycast.normal);
            _points.Add(raycast.point);

            if (GetPredictionLenght()) return;

            if (raycast.collider.gameObject.layer != 6) return;

            

          
        }
        
        
    }

    bool GetPredictionLenght()
    {
        float distance = 0f;
        Vector3 lastVector =_points[0];
        for(int i = 1; i < _points.Count; i++)
        {
            Vector3 vector = _points[i];

            distance += Vector3.Distance(lastVector, vector);


            if (distance > fireMode.predictionLenght)
            {
                float reaminingDistance = fireMode.predictionLenght - distance;
                Vector3 direction = vector - lastVector;
                Vector3 remainingVector = -(reaminingDistance + direction.magnitude) * direction.normalized;
                Vector3 directionVector = lastVector - remainingVector;
              

                _points.RemoveAt(_points.Count - 1);

                _points.Add(directionVector);
                return true;
            }



            lastVector = vector;


        }
        return false;
    }
}


