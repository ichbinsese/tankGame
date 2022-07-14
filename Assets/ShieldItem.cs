using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : Item
{
    public int rotationLag;
    public GameObject breakSound;
    private List<Quaternion> _rotations = new List<Quaternion>();
    public override void Use()
    {
        
    }

    public void FixedUpdate()
    {
        _rotations.Insert(0,GameManager.player.transform.GetChild(0).GetChild(0).rotation);
        if (_rotations.Count > rotationLag)
        { 
             transform.rotation = Quaternion.Euler(0,0, _rotations[rotationLag].eulerAngles.z-180);
            _rotations.RemoveAt(rotationLag);
        }
    }
    

    public override void Collect()
    {
        Instantiate(gameObject, GameManager.player.transform);
        transform.localPosition = Vector3.zero;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(breakSound, transform.position, Quaternion.identity);
        GameManager.player.GetComponent<PlayerItem>().RemoveItem();
        Destroy(gameObject);
    }
}
