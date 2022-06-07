using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public FireMode fireMode;
    public Transform bulletSpawner;
    public LineRenderer predictionLine;
    private List<Vector3> _points = new List<Vector3>();
    private float _cooldown;



    void Update()
    {
        if (_cooldown > 0) _cooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           Fire();
        }

        PredictShot();
    }

    protected virtual void Fire()
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

    protected virtual void PredictShot()
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

