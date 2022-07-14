using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : Item
{
    public float speedBoost;
    public float rotationBoost;
    public float duration;
    
    
    private float _normalPlayerSpeed;
    private float _normalPlayerRotation;
    private float _time;

    private void Start()
    {
        _normalPlayerSpeed = GameManager.player.GetComponent<PlayerController>().movementSpeed;
        _normalPlayerRotation = GameManager.player.GetComponent<PlayerController>().rotationSpeed;
    }

    private void Update()
    {
        if(_time > 0) _time -= Time.deltaTime;
        else
        {
            GameManager.player.GetComponent<PlayerController>().movementSpeed = _normalPlayerSpeed;
            GameManager.player.GetComponent<PlayerController>().rotationSpeed = _normalPlayerRotation;
            if(uses <= 0) Destroy(gameObject);
        }
        
    }

    public override void Collect()
    {
        Spawn();
    }   

    public override void Use()
    {
        print(_time);
        if(_time > 0) return;
        uses--;
        GameManager.player.GetComponent<PlayerController>().movementSpeed = _normalPlayerSpeed + speedBoost;
        GameManager.player.GetComponent<PlayerController>().rotationSpeed = _normalPlayerRotation + rotationBoost;
        _time = duration;
        if(uses > 0)  return;
        GameManager.player.GetComponent<PlayerItem>().RemoveItem();
        

    }
}
