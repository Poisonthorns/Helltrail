using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
	{
        currentHealth -= damage;
        if(currentHealth <= 0)
            Death();

	}

<<<<<<< HEAD
            }
            else if (getSquareDistance(new Coords(currentPosition.x , currentPosition.y+1), playerPosition) < distance)
            {
                this.transform.position = grid.GetCellCenterWorld(new Vector3Int(currentPosition.x, currentPosition.y-1, 0));
                currentPosition = new Coords(currentPosition.x , currentPosition.y+1);

            }
            else if (getSquareDistance(new Coords(currentPosition.x, currentPosition.y-1), playerPosition) < distance)
            {
                this.transform.position = grid.GetCellCenterWorld(new Vector3Int(currentPosition.x , currentPosition.y-1, 0));
                currentPosition = new Coords(currentPosition.x , currentPosition.y-1);

            }
        }
    }
    public bool detection()
    {
        return getSquareDistance(currentPosition, playerPosition)<4;
    }
    public void attack()
    {
        player.GetComponent<Player>().TakeDamage(100);
    }
=======
>>>>>>> parent of 4aed1e8... enemy attack and movement
    void Death()
	{
        UnityEngine.Debug.Log(this.name + " died");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
	}
}
