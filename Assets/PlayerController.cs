using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Transform rotator;
    public Transform tower;

    public float rotationSpeed;
    public float movementSpeed;


    public TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        movementSpeed += Input.mouseScrollDelta.y / 4;
        txt.text = movementSpeed.ToString();
        

        //rotation
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosVector = mousePos - (Vector2) transform.position;
        float rotation = Mathf.Acos(Vector2.Dot(mousePosVector, Vector2.up) / mousePosVector.magnitude); //omg Mathematik Untericht
        rotation *= Mathf.Rad2Deg;
        if (mousePosVector.x > 0)rotation = -rotation; //omg das macht das es funktiniert
        rotator.eulerAngles = new Vector3(0f, 0f, rotation);

        //movement
        float radialMovement = Input.GetAxis("Horizontal");
        float vericalMovement = Input.GetAxis("Vertical");

        _rb.rotation -= radialMovement * rotationSpeed;
        _rb.position -=  (Vector2) ((vericalMovement * movementSpeed / 100) * transform.up);
        //rotator.transform.localPosition = new Vector2(0, -0.0625f);
        

    }
}
