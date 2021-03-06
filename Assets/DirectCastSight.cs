using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectCastSight : EnemySight
{
   public override bool CheckSight()
   {
      int layermask1 = 1 << 8;
      int layermask2 = 1 << 9;
      int layermask3 = 1 << 10;
      int finalmask  = layermask1 | layermask2 | layermask3;
      RaycastHit2D raycast = Physics2D.Raycast(transform.position,
         GameManager.player.transform.position - transform.position,Mathf.Infinity,~finalmask);
      return raycast.collider == GameManager.player.GetComponent<Collider2D>();
      
   }
}
