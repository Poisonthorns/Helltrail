using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CastSpell : MonoBehaviour
{
    public GameObject iceSpikes;
    public GameObject fireBall;
    public GameObject gridObject;
    public GameObject tileMapObject;

    public AudioClip iceSound;
    public AudioClip fireSound;

    private AudioSource satanSpellAudio;
    public void iceSpell()
    {
        satanSpellAudio.PlayOneShot(iceSound);
        Grid grid = gridObject.GetComponent<Grid>();
        Tilemap tilemap = tileMapObject.GetComponent<Tilemap>();
        Instantiate(iceSpikes, grid.GetCellCenterWorld(new Vector3Int(0, 0, 0)), Quaternion.identity);

        for (int i=0; i<2; ++i)
        {
            Vector3 temp = grid.GetCellCenterWorld(new Vector3Int(Random.Range(0, 10) - 5, Random.Range(0, 10) - 5, 0));
            Instantiate(iceSpikes,new Vector3(temp.x, temp.y, 0f) , Quaternion.identity);

        }

    }
    public void fireBallSpell()
    {
        satanSpellAudio.PlayOneShot(fireSound);
        Grid grid = gridObject.GetComponent<Grid>();
        Tilemap tilemap = tileMapObject.GetComponent<Tilemap>();
        Instantiate(fireBall, grid.GetCellCenterWorld(new Vector3Int(0, 0, 0)), Quaternion.Euler(0, 0, 90));




    }
    void Start()
    {
        satanSpellAudio = gameObject.GetComponent<AudioSource>();
        iceSpell();
    }
}
