using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ItemBox : MonoBehaviour
{
    public List<Item> items;
    private Item _item;
    public Sprite randomSprite;

    private void Start()
    {
        Sprite sprite;
        if (items.Count > 1)
        {
            _item = items[Random.Range(0, items.Count)];
            sprite = randomSprite;
        }
        else
        {
            _item = items[0];
            sprite = _item.smallSprite;
        }
        GetComponentsInChildren<SpriteRenderer>()[1].sprite = sprite;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("nur");
        if (col.gameObject == GameManager.player)
        {
            if(col.GetComponent<PlayerItem>().CollectItem(_item)) Destroy(gameObject);
        }
    }
}
