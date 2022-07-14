using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public Item item;
    public Slider itemDurability;
    public GameObject itemMonitor;
    public Image itemIcon;
    


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && item != null)item.Use();
        if(item != null) itemDurability.value = item.uses;
    }

    public bool CollectItem(Item collectItem)
    {
        if (item != null) return false;
        item = collectItem;
        itemMonitor.SetActive(true);
        itemDurability.maxValue = item.uses;
        itemIcon.sprite = item.bigSprite;
        item.Collect();
        return true;
    }

    public void RemoveItem()
    {
        item = null;
        itemMonitor.SetActive(false);
        
    }
    
    
    
}
