using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float uses;
    public Sprite smallSprite;
    public Sprite bigSprite;
    public virtual void Use()
    {

    }
    
    public virtual void Spawn()
    { 
        GameObject go = Instantiate(gameObject, GameManager.player.transform);
        GameManager.player.GetComponent<PlayerItem>().item = go.GetComponent<Item>();
       
    }

    public virtual void Collect()
    {
        
    }
}
