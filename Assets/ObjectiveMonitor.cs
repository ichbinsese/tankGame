using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveMonitor : MonoBehaviour
{
    public List<Objective> objectives;
    public TextMeshProUGUI objectiveCounter;

    private void Start()
    {
        objectives.AddRange(FindObjectsOfType<Objective>()); 
        objectiveCounter.text = objectives.Count.ToString();
    }

    public void CollectObjective(Objective objective)
    {
        objectives.Remove(objective);
        objectiveCounter.text = objectives.Count.ToString();
        if (objectives.Count == 0) LevelComplete();
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(0);
    }


}
