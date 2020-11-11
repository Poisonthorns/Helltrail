using UnityEngine;
using UnityEngine.Assertions;

public class EnemyMovementManager : MonoBehaviour
{
    /* Movement Boolean Array size should be 4
     * Only set 1 as true!
     * 0 = towards the player
     * 1 = away from the player
     * 2 = randomly 
     * 3 = no movement
     */
    public bool[] movementType;

    public Transform player;

    public float speed;
    public Transform movePoint;
    public LayerMask collideables;
    public int powerLevel;
    private float nextMovement = 0.0f;
    public float movementInterval = 2.0f;
    void Start()
    {
        int numTrue = 0;
        foreach (bool i in movementType)
        {
            if (i)
            {
                numTrue++;
            }
        }
        Assert.IsTrue(numTrue == 1);

        movePoint.parent = null;
        nextMovement = Time.time + Random.Range(0.0f, 3.0f);
    }

    /*
    // Changed to FixedUpdate
    void Update()
    {
        player = GameObject.Find("Player").transform;
        if(Time.time > nextMovement)
        {
            nextMovement += movementInterval;
            setMovement();
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
    } */

    void FixedUpdate()
    {
        player = GameObject.Find("Player").transform;
        if (Time.time > nextMovement)
        {
            nextMovement += movementInterval;
            setMovement();
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
    }

    private void setMovement()
    {
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.02f)
        {
            Vector3 moveDirection = getMovement();
            if(!Physics2D.OverlapCircle(movePoint.position + moveDirection, .2f, collideables))
            {
                movePoint.position += moveDirection;
            }
        }

    }

    private Vector3 getMovement()
	{
        if(movementType[0])
		{
            return directionTowardsPlayer();
        }
        else if (movementType[1])
        {
            return directionAwayFromPlayer();
        }
        else if (movementType[2])
        {
            return directionRandom();
        }

        return new Vector3(0f, 0f, 0f);
    }

    private Vector3 directionTowardsPlayer()
    {
        Vector3 dir = player.position - transform.position;
        //Debug.Log(dir.x + " " + dir.y);
        if (Mathf.Abs(dir.x) < 1.0f && Mathf.Abs(dir.y) < 1.0f)
        {
            dir.x = 0.0f;
            dir.y = 0.0f;
        }
        else
        {
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                if (dir.x > 0)
                {
                    dir.x = 1.0f;
                }
                else
                {
                    dir.x = -1.0f;
                }

                dir.y = 0.0f;
            }
            else
            {
                if (dir.y > 0)
                {
                    dir.y = 1.0f;
                }
                else
                {
                    dir.y = -1.0f;
                }

                dir.x = 0.0f;
            }


        }

        return dir;
    }

    private Vector3 directionAwayFromPlayer()
    {
        
        return directionTowardsPlayer() * -1.0f;
    }

    private Vector3 directionRandom()
    {
        return new Vector3(Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, speed)), Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, speed)), 0f);
    }
}