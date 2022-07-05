using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;


public class ShadowCreator : MonoBehaviour
{
    public Tilemap wallTilemap;
    public Tilemap breakableWallTilemap;
    public Transform compositeShadowParent;
    public GameObject shadowPrefab;

    private void Start()
    {
        CreateWallShadows(wallTilemap);
        CreateWallShadows(breakableWallTilemap);
    }

    private void CreateWallShadows(Tilemap tm )
    {

        for (int x = tm.cellBounds.xMax; x != tm.cellBounds.xMin; x--)
        {
            for (int y = tm.cellBounds.yMax; y != tm.cellBounds.yMin; y--)
            {
               if(tm.GetTile(new Vector3Int(x - 1,y - 1))  != null )  Instantiate(shadowPrefab, new Vector3(x, y), Quaternion.identity, compositeShadowParent);
            }
        }
        


    }

    public void UpdateBreakableShadows()
    {
        //TODO: WENIGER BEHINDERT MACHEN !!!
        foreach (ShadowCaster2D shadow in compositeShadowParent.GetComponentsInChildren<ShadowCaster2D>())
        {
            if(breakableWallTilemap.GetTile(new Vector3Int((int)  shadow.transform.position.x - 1,(int) shadow.transform.position.y - 1))  == null && 
               wallTilemap.GetTile(new Vector3Int((int)  shadow.transform.position.x - 1,(int) shadow.transform.position.y - 1)) == null ) Destroy(shadow.gameObject);
        }
        
    }
}
