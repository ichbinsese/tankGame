using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartStationaryEnemy : EnemyAI
{
   /*
   private int _tries = 100;
   protected override void Update()
   {
      //base.Update();

      if(attack.GetCooldown() > 0) return;
      TryFire();

      
   }
   protected override void OnPlayerSpot()
   {
      base.OnPlayerSpot();
      attack.SetCooldown();
   }

   protected virtual void TryFire()
   {
      for (int i = 0; i < _tries; i++)
      {
         float p = (float)i / (float)_tries * 2*Mathf.PI;
         Vector2 direction = new Vector2(Mathf.Sin(p), Mathf.Cos(p));
         Vector2 startDirection = direction;
         
        

         Vector2 point = transform.position;

         
         for (int j = 0; j <= attack.fireMode.durability ; j++)
         {
            RaycastHit2D raycast = Physics2D.Raycast(point, direction, Mathf.Infinity, ~8);

 
            if (raycast.collider.gameObject == gameObject) break;
            if (raycast.collider.gameObject == GameManager.player)
            {
               
               if (!playerInSight) OnPlayerSpot();
               enemy.RotateToFace(startDirection + (Vector2)transform.position);
               attack.Fire();
               return;
            }
            
            point = raycast.point;
            direction = Vector2.Reflect(direction, raycast.normal);

            
            //if (raycast.collider.gameObject.layer != 6) break;

         }

      }
      if(playerInSight) OnPlayerLoss();
   }
   */
}
