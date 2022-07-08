using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirectLineMovementBehaviour : EnemyMovementBehaviour
{
    
    public float rotationSpeed;
    public float movementSpeed;
    public float saveDistance;

    private Rigidbody2D _rb;
    
    private Vector2 _desiredDirection;
    private Vector2 _desiredPosition;
    private Vector2 _spawnPosition;
    private bool _rotating;
    private bool _moving;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spawnPosition = transform.position;
    }
    public override void FollowingBehaviour()
    {
        base.FollowingBehaviour();

        if (!(Vector3.Distance(transform.position, GameManager.player.transform.position) > saveDistance)) return;
        if (_rotating) ExecuteRotation();
        if (_moving) ExecuteMovement();
        MoveToPosition(lastPlayerPos);
    }

    public override void SearchingBehaviour()
    {
        base.SearchingBehaviour();
        
        if(!_moving && !_rotating) onPlayerLost.Invoke();
        int layermask1 = 1 << 8;
        int layermask2 = 1 << 9;
        int finalmask  = layermask1 | layermask2;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, GameManager.player.transform.position - transform.position,Vector2.Distance(_spawnPosition,transform.position),~finalmask);
        if (raycast.collider != null)
        {
            onPlayerLost.Invoke();
            return;
        }
        Vector2 p = (Vector2)transform.position - _spawnPosition;
        if (decimal.Round((decimal)p.x, 1) == 0 && decimal.Round((decimal)p.y, 1) == 0) onPlayerLost.Invoke();
        if (_rotating) ExecuteRotation();
        if (_moving) ExecuteMovement();
       
        MoveToPosition(_spawnPosition);
        
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
    
    public void MoveToPosition(Vector2 point)
    {
        _desiredDirection = _desiredPosition = point;
        _rotating = true;
        _moving = true;

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

