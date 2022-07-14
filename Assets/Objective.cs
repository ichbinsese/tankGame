using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private ObjectiveMonitor _objectiveMonitor;

    public void Collect()
    {
       if(_objectiveMonitor != null) _objectiveMonitor.CollectObjective(this);
    }
    void Start()
    {
        _objectiveMonitor = FindObjectOfType<ObjectiveMonitor>();
    }

    // Update is called once per frame
}
