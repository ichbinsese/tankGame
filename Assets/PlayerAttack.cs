using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Weapon weapon;




    void Update()
    {
        weapon.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        weapon.Visualize();
    }

}    

