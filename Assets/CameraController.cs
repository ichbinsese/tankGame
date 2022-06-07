using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Collider2D cameraZone;
    public int followDelay;
    private BoxCollider2D _cameraViewCollider;
    private List<Vector2> _playerPositions = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {

        _cameraViewCollider = GetComponent<BoxCollider2D>();


        //Wenn sachen nicht funktionieren das villeicht in update??
        Vector2 bounds = new Vector2((float)Screen.width / (float)Screen.height * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
        _cameraViewCollider.size = bounds;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector2 playerPosScreenSpace = Camera.main.WorldToScreenPoint(Player.player.transform.position);
        _playerPositions.Insert(0, GameManager.player.transform.position);
        if (_playerPositions.Count <= followDelay) return;

        Vector2 movePosition = _playerPositions[followDelay];
        Vector2 resultingPositon = transform.position;

        _cameraViewCollider.offset = new Vector2(movePosition.x - transform.position.x, 0);
        if (CameraInsideZone()) resultingPositon = new Vector2(movePosition.x, resultingPositon.y);
        _cameraViewCollider.offset = new Vector2(0,movePosition.y - transform.position.y);
        if (CameraInsideZone()) resultingPositon = new Vector2(resultingPositon.x, movePosition.y);
        _cameraViewCollider.offset = Vector2.zero;


        transform.position = resultingPositon;

        _playerPositions.RemoveAt(followDelay);

        print(CameraInsideZone());

    }


    bool CameraInsideZone()
    {
        return cameraZone.bounds.Contains(_cameraViewCollider.bounds.min) && cameraZone.bounds.Contains(_cameraViewCollider.bounds.max);

    }
}
