﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Tilemaps;
using UnityEngine.Tilemaps;
public struct Room
{
    public Room(Coords entrancee, Coords doorr, int doorSidee, int entranceSidee)
    {
        entrance = entrancee;
        door = doorr;
        doorSide = doorSidee;
        entranceSide = entranceSidee;
    }

    public Coords entrance { get; }
    public Coords door { get; }
    public int doorSide { get; }
    public int entranceSide { get; }
}
public class CircleCreation : MonoBehaviour
{
    
    int rooms = 4;
    int roomXSize = 10;
    int roomYSize = 10;
    public Tile[] sprite;
    public TileBase tiles;
    Room[] roomMap;
    Coords[] entrance;
    void Start()
    {
        roomMap = new Room[4];
       RoomGenerator temp = new RoomGenerator();
        int roomWidth = 10;
        int roomHeight = 10;
        Coords entrance = new Coords(0, 5);
        Coords roomDoor = new Coords(3, 0);
        Coords roomDoor2 = new Coords(9, 4);
        Coords roomDoor3 = new Coords(7, 9);
        Coords[] array = new Coords[] { roomDoor, roomDoor2, roomDoor3 };

        int[] monsters = new int[] { 0, 5, 4, 3 };
        int[] terrain = new int[10];
        for (int i = 0; i < 10; ++i)
        {
            terrain[i] = i + 19;
        }
        path();
        List<int[,]> roomsss = new List<int[,]>();
        for(int i=0; i<roomMap.Length; ++i)
        {
           roomsss.Add(temp.generateRoom(roomWidth, roomHeight, roomMap[i].entrance, roomMap[i].door, monsters, terrain));
            temp.printMap();
        }
        //next part is creating the actual map
        GameObject grid = new GameObject("grid");
        grid.AddComponent<Grid>();
        GameObject[] roomssssss = new GameObject[roomsss.Count*2];

        for(int i=0; i< roomsss.Count; ++i)
        {
            GameObject newRoom = new GameObject("newRoom0");
            newRoom.AddComponent<Tilemap>();
            newRoom.AddComponent<TilemapRenderer>();
            newRoom.transform.parent = grid.transform;

            GameObject newRoomCollision = new GameObject("collision");
            newRoomCollision.AddComponent<Tilemap>();
            newRoomCollision.AddComponent<TilemapRenderer>();
            newRoomCollision.layer = 8;
            newRoomCollision.transform.parent = grid.transform;
            newRoomCollision.AddComponent<TilemapCollider2D>();
            newRoomCollision.AddComponent<Rigidbody2D>();
            newRoomCollision.AddComponent<CompositeCollider2D>();
            newRoomCollision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            roomssssss[i*2] = newRoom;
            roomssssss[(i*2)+1] = newRoomCollision;
        }


        Tile tile = sprite[0];
        Tile tile2 = sprite[1];
        Tile tile3 = sprite[2];

        int tileOffsetX = 0;
        int tileOffsetY = 0;
        int switcher = 0;
        for (int x = 0; x < roomsss.Count; ++x)
        {
            int[,] test = roomsss[x];
            Tilemap tileMap = roomssssss[x*2].GetComponent<Tilemap>();
            Tilemap tileMapCollision = roomssssss[(x*2)+1].GetComponent<Tilemap>();
            //set appropriate tiles
            for (int i = -1; i < roomXSize + 1; ++i)
            {
                for (int j = -1; j < roomYSize + 1; ++j)
                {
                    if(i == -1 && j == roomYSize)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[11]);

                    }
                    else if (i == roomXSize && j == roomYSize)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[13]);

                    }
                    else if (i == -1 && j == -1)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[12]);

                    }
                    else if (i == roomXSize && j == -1)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[14]);

                    }
                    else if (i== -1)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[15]);

                    }
                    else if (i == roomXSize)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[16]);

                    }
                    else if(j == roomYSize)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[17]);

                    }
                    else if (j == -1)
                    {
                        tileMap.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[18]);

                    }
                }
            }
            for (int i = 0; i < roomXSize; ++i)
            {
                for (int j = 0; j < roomYSize; ++j)
                {
                    tileMap.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), tile);

                    if (test[i, j] > 10 && test[i, j] != 99)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i+tileOffsetX, j + tileOffsetY, 0), tile2);

                    }
                    else if (test[i, j] == 99|| test[i, j] == -1)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), tile3);
                        if (test[i, j] == -1)
                        {
                            if (i == roomXSize - 1)
                            {
                                switcher = 0;
                            }
                            else if (i == 0)
                            {
                                switcher = 1;
                            }
                            else if (j == roomYSize - 1)
                            {
                                switcher = 2;
                            }
                            else if (j == 0)
                            {
                                switcher = 3;
                            }
                        }
                    }

                }
            }
            //get offset depending on position of next room
            switch (switcher)
            {
                case 0:
                     tileOffsetX += 12;
                    break;
                case 1:
                    tileOffsetX -= 12;
                    break;
                case 2:
                    tileOffsetY += 12;
                    break;
                case 3:
                    tileOffsetY -= 12;
                    break;
                default:
                    break;
            }
          
            tileMap.RefreshAllTiles();
        }

    }
    //
    void path()
    {

        Coords temp = new Coords(roomXSize / 2, 0);
        Room room1 = new Room(temp, generateRandomDoor(temp),  0, 0);
        roomMap[0] = room1;

        for(int i=1; i<rooms; ++i)
        {
            Coords temp2 = getNextRoomEntrance(roomMap[i - 1].door);
            roomMap[i] = new Room(temp2, generateRandomDoor(temp2), 0, 0);
        }

    }
    //given entrance, creates a random door thats not on the side of entrance
    Coords generateRandomDoor(Coords entrance)
    {
        int entranceSide = 0;
        if(entrance.x == roomXSize-1)
        {
            entranceSide = 1;
        }
        else if(entrance.x == 0)
        {
            entranceSide = 3;
        }
        else if (entrance.y == 0)
        {
            entranceSide = 0;
        }
        else if (entrance.y == roomYSize - 1)
        {
            entranceSide = 2;
        }
        int temp = Random.Range(1, 4);
        int side = (entranceSide + temp) % 4;
        if (side == 0)
        {
            return new Coords(Random.Range(1, roomXSize-1), 0);
        }
        else if (side == 1)
        {
            return new Coords(roomXSize-1, Random.Range(1, roomYSize-1));
        }
        else if (side == 2)
        {
            return new Coords(Random.Range(1, roomXSize-1), roomYSize - 1);
            
        }
        else if (side == 3)
        {
            return new Coords(0, Random.Range(1, roomYSize-1));
        }
        else
        {
            print("this should not happen");
            return new Coords(-1, -1);
        }
    }
    //given previous room's door finds the entrance door
    Coords getNextRoomEntrance(Coords prevRoomDoor)
    {
        if(prevRoomDoor.x==0)
        {
            return new Coords(roomXSize - 1, prevRoomDoor.y);
        }
        else if (prevRoomDoor.x == roomXSize - 1)
        {
            return new Coords(0, prevRoomDoor.y);
        }
        else if (prevRoomDoor.y == roomYSize - 1)
        {
            return new Coords(prevRoomDoor.x, 0 );
        }
        else if (prevRoomDoor.y == 0)
        {
            return new Coords(prevRoomDoor.x, roomYSize - 1);
        }
        else
        {
            print("this should not happen");
            return new Coords(-1, -1);
        }
    }
    void createPath()
    {

    }
}
