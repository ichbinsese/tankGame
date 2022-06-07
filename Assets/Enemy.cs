using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D _rb;
    public Transform rotator;
    
    public float rotationSpeed;
    public float movementSpeed;

    public Transform tower;

    private Vector2 _desiredDirection;
    private Vector2 _desiredPosition;

    private bool _rotating;
    private bool _moving;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rotator.transform.localPosition = new Vector2(0, -0.0625f);
        
        if (_rotating)ExecuteRotation();
        if(_moving) ExecuteMovement();

       
    }

    

    public void RotateToFace(Vector2 point)
    {
        

    }

    public bool CheckLineOfSight()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, GameManager.player.transform.position - transform.position);
        Debug.DrawRay(transform.position, GameManager.player.transform.position);
        return raycast.collider == GameManager.player.GetComponent<Collider2D>();
       
    }

    public bool CheckDistance(float range)
    {
        return Vector2.Distance(transform.position, GameManager.player.transform.position) <= range;
    }

    public void SetDesiredRotation(Vector2 point)
    {
        _desiredDirection = point;
        _rotating = true;
    }

    public void MoveToPositionInSight(Vector2 point)
    {
        _desiredDirection = _desiredPosition = point;
        _rotating = true;
        _moving = true;

    }


    private void ExecuteRotation()
    {
        Vector2 pointPosVector = _desiredDirection - (Vector2)transform.position;
        float desiredRotation = Mathf.Acos(Vector2.Dot(pointPosVector, Vector2.up) / pointPosVector.magnitude);
        desiredRotation *= Mathf.Rad2Deg;
        if (pointPosVector.x > 0) desiredRotation = -desiredRotation;


        float turnDirection = -Vector3.Cross(transform.up, transform.position - (Vector3)_desiredDirection).normalized.z;
        if (LooksInDesiredDirection())
        {
            _rb.rotation = desiredRotation;
            _rotating = false;

        }
        //wenn direket dahinter snappt aber grad kb das zu fixen lol
        else _rb.rotation += rotationSpeed * turnDirection;
    
    }

    private void ExecuteMovement()
    {
        if (_rotating) return;
        Vector2 p = (Vector2)transform.position - _desiredPosition;
        if (decimal.Round((decimal)p.x, 1) == 0 && decimal.Round((decimal)p.y, 1) == 0) _moving = false;
        else _rb.position += (Vector2)((movementSpeed * movementSpeed / 100) * transform.up);
    }

    private bool LooksInDesiredDirection()
    {
        Vector3 rot = Vector3.Cross(transform.up, transform.position - (Vector3)_desiredDirection);
        return Mathf.RoundToInt(rot.z) == 0;
    }


    



}
