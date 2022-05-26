using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Collider2D cameraZone;
    public int followDelay;
    private BoxCollider2D cameraViewCollider;
    private List<Vector2> playerPositions = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {

        cameraViewCollider = GetComponent<BoxCollider2D>();


        //Wenn sachen nicht funktionieren das villeicht in update??
        Vector2 bounds = new Vector2((float)Screen.width / (float)Screen.height * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
        cameraViewCollider.size = bounds;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector2 playerPosScreenSpace = Camera.main.WorldToScreenPoint(Player.player.transform.position);
        playerPositions.Insert(0, GameManager.player.transform.position);
        if (playerPositions.Count <= followDelay) return;

        Vector2 movePosition = playerPositions[followDelay];
        Vector2 resultingPositon = transform.position;

        cameraViewCollider.offset = new Vector2(movePosition.x - transform.position.x, 0);
        if (CameraInsideZone()) resultingPositon = new Vector2(movePosition.x, resultingPositon.y);
        cameraViewCollider.offset = new Vector2(0,movePosition.y - transform.position.y);
        if (CameraInsideZone()) resultingPositon = new Vector2(resultingPositon.x, movePosition.y);
        cameraViewCollider.offset = Vector2.zero;


        transform.position = resultingPositon;

        playerPositions.RemoveAt(followDelay);

        print(CameraInsideZone());

    }


    bool CameraInsideZone()
    {
        return cameraZone.bounds.Contains(cameraViewCollider.bounds.min) && cameraZone.bounds.Contains(cameraViewCollider.bounds.max);

    }
}
