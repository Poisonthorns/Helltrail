using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CastSpell : MonoBehaviour
{
    public GameObject iceSpikes;
    public GameObject gridObject;
    public GameObject tileMapObject;
    void iceSpell()
    {
        Grid grid = gridObject.GetComponent<Grid>();
        Tilemap tilemap = tileMapObject.GetComponent<Tilemap>();
        Instantiate(iceSpikes, grid.GetCellCenterWorld(new Vector3Int(0, 0, 0)), Quaternion.identity);

        for (int i=0; i<2; ++i)
        {

            Instantiate(iceSpikes, grid.GetCellCenterWorld(new Vector3Int(Random.Range(0, 10)-5, Random.Range(0, 10) - 5, 0)), Quaternion.identity);

        }

    }
    void Start()
    {
        iceSpell();
    }
}
