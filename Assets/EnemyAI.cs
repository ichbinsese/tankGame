using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    protected Enemy enemy;
    protected EnemyAttack attack;
    protected bool playerInSight;
    protected Vector2 lastPlayerPos;
    public UnityEvent vent;
    
    protected virtual void Start()
    {
        enemy = GetComponent<Enemy>();
        attack = GetComponent<EnemyAttack>();
        
    }

    protected virtual void Update()
    {
        if (!playerInSight && enemy.CheckLineOfSight()) OnPlayerSpot();
        if (playerInSight && !enemy.CheckLineOfSight()) OnPlayerLoss();

    }

    protected virtual void OnPlayerSpot()
    {
        playerInSight = true;
        lastPlayerPos = GameManager.player.transform.position;

    }

    protected virtual void OnPlayerLoss()
    {
        playerInSight = false;

    }
}
