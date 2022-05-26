using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public bool healthEnabled;
    public GameObject player;
    void Start()
    {
        GameManager.player = player;
        GameManager.healthEnabled = healthEnabled;
        
    }


}
