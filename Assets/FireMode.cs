using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FireMode", order = 1)]
public class FireMode : ScriptableObject

{
    public GameObject projectile;
    public float fireSpeed;
    public int durability;
    public float predictionLenght;
    public int damage;


}
