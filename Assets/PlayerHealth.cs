using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : Health
{
    public GameObject deathAnimation;
    public GameObject deathUI;
    public override void Destroy()
    {
        StartCoroutine("ActivateEffects");
    }

    public IEnumerator ActivateEffects()
    {
        foreach (VolumeComponent volume in  FindObjectOfType<Volume>().profile.components)
        {
            volume.active = true;
        }
        Instantiate(deathAnimation,transform.position,transform.rotation);
        foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.enabled = false;
        }
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<RocketLauncher>().predictionLine.gameObject.SetActive(false);
        GetComponent<Mortar>().visLight.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        deathUI.SetActive(true);


    }

}
