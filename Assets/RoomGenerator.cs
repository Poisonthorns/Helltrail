using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Coords
{
    public Coords(int X, int Y)
    {
        x = X;
        y = Y;
    }

    public int x { get; }
    public int y { get; }
}
public class RoomGenerator : MonoBehaviour
{
    int roomSizeX;
    int roomSizeY;
    Coords start;
    Coords[] door;
    List<Coords> monsters;
    List<Coords> terrain;
    int[,] roomGrid;
    public RoomGenerator()
    {
        monsters = new List<Coords>();
        terrain = new List<Coords>();
        
    }
    
    //monsterID must be < 10
    //terrainID must be > 10
    public void generateRoom(int roomWidth, int roomHeight, Coords entrance, Coords[] roomDoor, int[] monster, int[] stuff)
    {
        roomSizeX = roomWidth;
        roomSizeY = roomHeight;
        start = entrance;
        door = new Coords[roomDoor.Length];
        for(int i=0; i<roomDoor.Length; ++i)
        {
            door[i] = roomDoor[i];
        }
        //randomly generates map until nothing is blocked
        do
        {
            //reset map
            monsters.Clear();
            terrain.Clear();
            roomGrid = new int[roomWidth, roomHeight];
            //generate map
            generateMonsters(monster);
            generateTerrain(stuff);

        } while (isPossible());//checks generated map is possible

        roomGrid[start.x, start.y] = 99;
        for(int i=0; i<door.Length; ++i)
        {
            roomGrid[door[i].x, door[i].y] = -1;
        }
    }
    //prints map
    public void printMap()
    {

        for(int i=0; i<roomSizeX; ++i)
        {
            string s = "";
            for (int j = 0; j < roomSizeY; ++j)
            {
                s+= roomGrid[i, j] + " ";
            }
            print(s);
        }
    }
    //places all the monsters on the map
    void generateMonsters(int[] monster)
    {
        for(int i=0; i<monster.Length; ++i)
        {
            Coords coord = new Coords(Random.Range(0, roomSizeX), Random.Range(0, roomSizeY));
            //checks if something is already there or too close to the entrance
            if(roomGrid[coord.x,coord.y]!=0 && getSquareDistance(start, coord) < 4)
            {
                --i;
            }
            else
            {
                roomGrid[coord.x,coord.y] = monster[i];
                monsters.Add(new Coords(coord.x, coord.y));
            }
        }
    }
    //generates terrain
    void generateTerrain(int[] stuff)
    {
        for (int i = 0; i < stuff.Length; ++i)
        {
            Coords coord = new Coords(Random.Range(0, roomSizeX), Random.Range(0, roomSizeY));
            //checks if something is already their or too close to entrance
            if (roomGrid[coord.x,coord.y] != 0 && getSquareDistance(start, coord) < 1)
            {
                --i;
            }
            else
            {
                //checks if it blocks door
                for(int j=0; j<door.Length;++j)
                {
                    if(getSquareDistance(door[j], coord)<1)
                    {
                        --i;
                        continue;
                    }
                }
                terrain.Add(new Coords(coord.x, coord.y));
                roomGrid[coord.x,coord.y] = stuff[i];
            }
        }
    }
    //checks if it is possible or not
    bool isPossible()
    {
        //checks if their is a path from start to doors
        if(!naiveDepth(start))
        {
            return false;
        }
        //checks if there is a path from monsters to doors(doing this check ensures no monsters are trapped)
        for(int i=0; i<monsters.Count; ++i)
        {
            if(!naiveDepth(monsters[i]))
            {
                return false;
            }
        }
        return true;
    }
    //depth first search; visits all eligable tiles.
    bool naiveDepth(Coords startt)
    {
        int[,] map = new int[roomSizeX ,roomSizeY];
        map[startt.x, startt.y] = 1;

        helper(map, startt.x, startt.y);
        //checks if nothing blocks the doors(prob unnecessary)
        for(int i=0; i<door.Length; ++i)
        {
            if(map[door[i].x, door[i].y]==0)
            {
                return false;
            }
        }
        return true;
    }
    //helper for depth search
    void helper(int[,] map, int x, int y)
    {
        map[x, y] = 1;
        if (x + 1 < roomSizeX && roomGrid[x + 1,y] < 10 &&  map[x+1,y]==0)
        {
            helper(map, x + 1, y);
        }
        if (x - 1 >= 0 && roomGrid[x - 1,y] < 10&&  map[x - 1, y] == 0)
        {
            helper(map, x - 1, y);
        }
        if (y + 1 < roomSizeY && roomGrid[x,y + 1] < 10 &&  map[x, y+1] == 0)
        {
            helper(map, x, y +1);
        }
        if (y - 1 >= 0 && roomGrid[x,y - 1] < 10 &&  map[x , y-1] == 0)
        {
            helper(map, x , y-1);
        }

    }
    //function to get distance between coordinates.(travel distance not physical)
    int getSquareDistance(Coords coord1, Coords coord2)
    {
        return Mathf.Abs(coord1.x - coord2.x) + Mathf.Abs(coord1.y - coord2.y);
    }
}
