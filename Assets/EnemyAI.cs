using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    private EnemySight _sight;
    public State state;
    public UnityEvent onPlayerSpot;
    public UnityEvent onSightLost;
    public UnityEvent onPlayerLost;
    
    
    private void Start()
    {
        _sight = GetComponent<EnemySight>();
    }

    private void Update()
    {
        bool result = _sight.CheckSight();
        if (result && state != State.Following)
        {
            onPlayerSpot.Invoke();
            OnPlayerSpot();
        } 
        else if (!result && state == State.Following)
        {
            onSightLost.Invoke();
            OnSightLost();
        }
    }
    public  void OnPlayerSpot()
    {
        state = State.Following;
    }

    public void OnSightLost()
    {
        state = State.Searching;
    }

    public void OnPlayerLost()
    {
        state = State.Roaming;
    }
    
    
    
}
