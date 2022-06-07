using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviour : MonoBehaviour
{
    public State state = State.Roaming;
    
    public UnityEvent onPlayerSpot;
    public UnityEvent onSightLost;
    public UnityEvent onPlayerLost;

    public Vector2 lastPlayerPos;
    public void Update()
    {
        switch (state)
        {
            case State.Roaming:
                RoamingBehaviour();
                break;
            case State.Following:
                FollowingBehaviour();
                break;
            case State.Searching:
                SearchingBehaviour();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public virtual void OnPlayerSpot()
    {
        state = State.Following;
    }

    public virtual void OnSightLost()
    {
        state = State.Searching;
    }

    public virtual void OnPlayerLost()
    {
        state = State.Roaming;
    }

    public virtual void RoamingBehaviour()
    {
        
    }
    public virtual void FollowingBehaviour()
    {
        lastPlayerPos = GameManager.player.transform.position;
    }
    
    public virtual void SearchingBehaviour()
    {
        
    }

}

public enum State
{
    Roaming = 0,
    Following = 1,
    Searching = 2,

}
