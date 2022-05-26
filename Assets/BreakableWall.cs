using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet;
        if (collision.collider.TryGetComponent<Bullet>(out bullet)){
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x + 0.1f * hit.normal.x;
                hitPosition.y = hit.point.y + 0.1f * hit.normal.y;

                print(hitPosition);
                GetComponent<Tilemap>().SetTile(GetComponent<Tilemap>().WorldToCell(hitPosition), null);
            }
                //bullet.Explode();
        }
    }
}
