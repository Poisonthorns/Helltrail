using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    RoomGenerator temp;
    void Start()
    {
        temp = new RoomGenerator();
        int roomWidth = 10;
        int roomHeight = 10;
        Coords entrance = new Coords(0, 5);
        Coords roomDoor = new Coords(3, 0);
        Coords roomDoor2 = new Coords(9, 4);
        Coords roomDoor3 = new Coords(7, 9);
        Coords[] array = new Coords[] { roomDoor, roomDoor2, roomDoor3 };

        int[] monsters = new int[] { 0, 5, 4 , 3};
        int[] terrain = new int[20];
        for(int i=0; i<20; ++i)
        {
            terrain[i] = i + 19;
        }
        //temp.generateRoom(roomWidth, roomHeight, entrance, array, monsters, terrain);
        temp.printMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
