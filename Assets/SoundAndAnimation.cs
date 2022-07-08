using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndAnimation : MonoBehaviour
{

    public float lifetime;
    public bool stayAlive = false;
    void Start()
    {
       GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (!(lifetime <= 0)) return;
        if(stayAlive) Destroy(this);
        else Destroy(gameObject);

    }
}
