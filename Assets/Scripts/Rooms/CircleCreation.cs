using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public struct Room
{
    public Room(Coords entrancee, Coords doorr, int offsetXa, int offsetYa, int[,] gridd)
    {
        entrance = entrancee;
        door = doorr;
        offsetX = offsetXa;
        offsetY = offsetYa;
        grid = gridd;
    }

    public Coords entrance;
    public Coords door;
    public int offsetX;
    public int offsetY;
    public int[,] grid;
}

public class CircleCreation : MonoBehaviour
{

    int roomCount = 4;
    public int roomXSize = 14;
    public int roomYSize = 8;
    int monsterOffset=2;
    int terrainOffset=20;
    public Tile[] sprite;
    public Tile[] rockSprite;
    public GameObject[] enemies;
    public GameObject playerPrefab;
    public int[] enemyEachFloor;
    public int[] rocksEachFloor;


    Room[] roomMap;
    Coords[] entrance;
    Grid g;
    Tilemap[] roomTileMaps;


    void Start()
    {
        roomMap = new Room[roomCount];
        roomTileMaps = new Tilemap[roomCount*2];
        RoomGenerator temp = new RoomGenerator();

        Coords entrance = new Coords(0, 7);


        

        path();
         
        for (int i = 0; i < roomMap.Length; ++i)
        {
            int[] monsters = new int[enemyEachFloor[i]] ;
            int[] terrain = new int[rocksEachFloor[i]];

            for (int j = 0; j < rocksEachFloor[i]; ++j)
            {
                terrain[j] = Random.Range(0, rockSprite.Length) + terrainOffset;
            }
            for (int j = 0; j < enemyEachFloor[i]; ++j)
            {
                monsters[j] = Random.Range(0, enemies.Length) + monsterOffset;
            }
            roomMap[i].grid = (temp.generateRoom(roomXSize, roomYSize, roomMap[i].entrance, roomMap[i].door, monsters, terrain));
        }
        //next part is creating the actual map

        gridCreation();

        setTiles();



       

    }
    void gridCreation()
    {
        GameObject grid = new GameObject("grid");
        grid.AddComponent<Grid>();
        g = grid.GetComponent<Grid>();
        GameObject[] roomssssss = new GameObject[roomCount * 2];

        for (int i = 0; i < roomCount; ++i)
        {
            GameObject newRoom = new GameObject("newRoom" + i);
            newRoom.AddComponent<Tilemap>();
            newRoom.AddComponent<TilemapRenderer>();
            newRoom.transform.parent = grid.transform;

            GameObject newRoomCollision = new GameObject("collision" + i);
            newRoomCollision.AddComponent<Tilemap>();
            newRoomCollision.AddComponent<TilemapRenderer>();
            newRoomCollision.layer = 8;
            newRoomCollision.transform.parent = grid.transform;
            newRoomCollision.AddComponent<TilemapCollider2D>();
            newRoomCollision.AddComponent<Rigidbody2D>();
            newRoomCollision.AddComponent<CompositeCollider2D>();
            newRoomCollision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            roomTileMaps[i * 2] = newRoom.GetComponent<Tilemap>();
            roomTileMaps[(i * 2) + 1] = newRoomCollision.GetComponent<Tilemap>(); ;
        }
    }
    void setTiles()
    {
        Tile tile = sprite[0];
        Tile tile2 = sprite[1];
        Tile tile3 = sprite[2];
        int tileOffsetX = 0;
        int tileOffsetY = 0;
        int switcher = 0;
        for (int x = 0; x < roomCount; ++x)
        {
            int[,] roomGrid = roomMap[x].grid;
            Tilemap tileMap = roomTileMaps[x * 2];
            Tilemap tileMapCollision = roomTileMaps[x * 2 + 1];
            roomMap[x].offsetX = tileOffsetX;
            roomMap[x].offsetY = tileOffsetY;
            //set appropriate tiles
            for (int i = -1; i < roomXSize + 1; ++i)
            {
                for (int j = -1; j < roomYSize + 1; ++j)
                {
                    if (i == -1 && j == roomYSize)
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
                    else if (i == -1)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[15]);

                    }
                    else if (i == roomXSize)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[16]);

                    }
                    else if (j == roomYSize)
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

                    tileMap.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), sprite[0]);

                    if (roomGrid[i, j] > 10 && roomGrid[i, j] != 99)
                    {
                        tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0), rockSprite[roomGrid[i,j]-terrainOffset]);
                    }
                    else if (roomGrid[i, j] == 99 || roomGrid[i, j] == -1)
                    {

                        if (roomGrid[i, j] == -1)
                        {
                            if (i == roomXSize - 1)
                            {
                                tileMap.SetTile(new Vector3Int(i + tileOffsetX + 1, j + tileOffsetY, 0), sprite[0]);
                                switcher = 0;
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX + 1, j + tileOffsetY, 0), null);

                            }
                            else if (i == 0)
                            {

                                tileMap.SetTile(new Vector3Int(i + tileOffsetX - 1, j + tileOffsetY, 0), sprite[0]);
                                switcher = 1;
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX - 1, j + tileOffsetY, 0), null);

                            }
                            else if (j == roomYSize - 1)
                            {
                                tileMap.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY + 1, 0), sprite[0]);
                                switcher = 2;
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY + 1, 0), null);

                            }
                            else if (j == 0)
                            {

                                tileMap.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY - 1, 0), sprite[0]);
                                switcher = 3;
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY - 1, 0), null);

                            }
                        }
                        else
                        {
                            if (i == roomXSize - 1)
                            {
                                tileMap.SetTile(new Vector3Int(i + tileOffsetX + 1, j + tileOffsetY, 0), sprite[0]);
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX + 1, j + tileOffsetY, 0), null);

                            }
                            else if (i == 0)
                            {

                                tileMap.SetTile(new Vector3Int(i + tileOffsetX - 1, j + tileOffsetY, 0), sprite[0]);
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX - 1, j + tileOffsetY, 0), null);

                            }
                            else if (j == roomYSize - 1)
                            {

                                tileMap.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY + 1, 0), sprite[0]);
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX, j + tileOffsetY + 1, 0), null);

                            }
                            else if (j == 0)
                            {

                                tileMap.SetTile(new Vector3Int(i + tileOffsetX + 1, j + tileOffsetY, 0), sprite[0]);
                                tileMapCollision.SetTile(new Vector3Int(i + tileOffsetX + 1, j + tileOffsetY, 0), null);

                            }

                        }
                    }
                    else
                    {
                    }
                    if (roomGrid[i, j] == 99 && x == 0)
                    {
                        Vector3Int cellPosition = new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0);
                        var newplayer = Instantiate(playerPrefab, g.GetComponent<Grid>().GetCellCenterWorld(cellPosition), Quaternion.identity);
                        newplayer.name = "Player";
                        Debug.Log("Player created");
                        GameObject potion = GameObject.Find("Potion");
                        //Pickup other = (Pickup)potion.GetComponent(typeof(Pickup));
                        //other.Initialize();
                        /*
                        GameObject camera = GameObject.Find("Main Camera");
                        Vector3Int cellPosition2 = new Vector3Int((roomXSize / 2) + tileOffsetX, (roomYSize / 2) + tileOffsetY, 0);
                        Vector3 camPos = g.GetComponent<Grid>().GetCellCenterWorld(cellPosition2);
                        camera.transform.position = new Vector3(camPos.x, camPos.y, -10);*/
                        GameObject move = GameObject.Find("Move Point");
                        move.transform.position = new Vector3(move.transform.position.x, move.transform.position.y, 0);
                    }
                    else if (roomGrid[i, j] < 10 && roomGrid[i, j] > 1)
                    {
                        Vector3Int cellPosition = new Vector3Int(i + tileOffsetX, j + tileOffsetY, 0);
                        Instantiate(enemies[roomGrid[i, j] - monsterOffset], g.GetComponent<Grid>().GetCellCenterWorld(cellPosition), Quaternion.identity);

                    }

                }
            }
            //get offset depending on position of next room
            switch (switcher)
            {
                case 0:
                    tileOffsetX += 16;
                    break;
                case 1:
                    tileOffsetX -= 16;
                    break;
                case 2:
                    tileOffsetY += 10;
                    break;
                case 3:
                    tileOffsetY -= 10;
                    break;
                default:
                    break;
            }

            tileMap.RefreshAllTiles();
        }
    }
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Vector3Int playerGridLocation = g.WorldToCell(player.transform.position);
        /*
        if (roomsss[currentRoom][playerGridLocation.x - roomMap[currentRoom].offsetX, playerGridLocation.y - roomMap[currentRoom].offsetY] == -1)
        {
            changeRoom();
        }*/
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            print("you win");
            SceneManager.LoadScene("Win Screen", LoadSceneMode.Single);
        }
    }
    void changeRoom()
    {
        /*
        currentRoom++;
        int[,] temp = roomsss[currentRoom];
        for (int i = 0; i < roomXSize; ++i)
        {
            for (int j = 0; j < roomYSize; ++j)
            {
                if (temp[i, j] == 99)
                {

                    GameObject player = GameObject.Find("Player");
                    Vector3Int cellPosition = new Vector3Int(i + roomMap[currentRoom].offsetX, j + roomMap[currentRoom].offsetY, 0);
                    player.transform.position = g.GetCellCenterWorld(cellPosition);
                    GameObject move = GameObject.Find("Move Point");
                    move.transform.position = g.GetCellCenterWorld(new Vector3Int(cellPosition.x, cellPosition.y, 0));

                    GameObject camera = GameObject.Find("Main Camera");
                    Vector3Int cellPosition2 = new Vector3Int((roomXSize / 2) + roomMap[currentRoom].offsetX, (roomYSize / 2) + roomMap[currentRoom].offsetY, 0);
                    Vector3 tempp = g.GetComponent<Grid>().GetCellCenterWorld(cellPosition2);
                    camera.transform.position = new Vector3(tempp.x, tempp.y, -10);

                }
            }
        }*/
    }
    void path()
    {

        Coords temp = new Coords(roomXSize / 2, 0);
        Room room1 = new Room(temp, generateRandomDoor(temp), 0, 0, null);
        roomMap[0] = room1;
        for (int i = 1; i < roomCount; ++i)
        {
            Coords entrancePosition = getNextRoomEntrance(roomMap[i - 1].door);
            roomMap[i] = new Room(entrancePosition, generateRandomDoor(entrancePosition), 0, 0, null);
        }

    }
    //given entrance, creates a random door thats not on the side of entrance
    Coords generateRandomDoor(Coords entrance)
    {
        int entranceSide = 0;
        if (entrance.x == roomXSize - 1)
        {
            entranceSide = 1;
        }
        else if (entrance.x == 0)
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
            return new Coords(Random.Range(1, roomXSize - 1), 0);
        }
        else if (side == 1)
        {
            return new Coords(roomXSize - 1, Random.Range(1, roomYSize - 1));
        }
        else if (side == 2)
        {
            return new Coords(Random.Range(1, roomXSize - 1), roomYSize - 1);

        }
        else if (side == 3)
        {
            return new Coords(0, Random.Range(1, roomYSize - 1));
        }
        else
        {
            print("this should not happen");
            return new Coords(-1, -1);
        }
    }
    int getSide(Coords coord)
    {
        if (coord.x == 0)
        {
            return 0;
        }
        else if (coord.x == roomXSize)
        {
            return 2;
        }
        else if (coord.y == 0)
        {
            return 3;
        }
        else if (coord.y == roomYSize)
        {
            return 1;
        }
        else
            return -1;
    }
    //given previous room's door finds the entrance door
    Coords getNextRoomEntrance(Coords prevRoomDoor)
    {
        if (prevRoomDoor.x == 0)
        {
            return new Coords(roomXSize - 1, prevRoomDoor.y);
        }
        else if (prevRoomDoor.x == roomXSize - 1)
        {
            return new Coords(0, prevRoomDoor.y);
        }
        else if (prevRoomDoor.y == roomYSize - 1)
        {
            return new Coords(prevRoomDoor.x, 0);
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

}