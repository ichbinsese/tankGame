using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FollowMovementBehaviour : EnemyMovementBehaviour
{
    public float minDistance;
    public float rotationSpeed;
    
    private Rigidbody2D _rb;

    private Vector2 _desiredDirection;
    private Vector2 _desiredPosition;

    private bool _rotating;
    private bool _moving;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void FollowingBehaviour()
    {
        if (_rotating)ExecuteRotation();
        base.FollowingBehaviour();
        
    }
    
    public void SetDesiredRotation(Vector2 point)
    {
        _desiredDirection = point;
        _rotating = true;
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
    
    private bool LooksInDesiredDirection()
    {
        Vector3 rot = Vector3.Cross(transform.up, transform.position - (Vector3)_desiredDirection);
        return Mathf.RoundToInt(rot.z) == 0;
    }
    
}
