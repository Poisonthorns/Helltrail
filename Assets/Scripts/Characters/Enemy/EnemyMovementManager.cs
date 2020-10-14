using UnityEngine;

public class EnemyMovementManager : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private bool moving;

    private Vector3 moveDirection;
    private float time = 0.0f;
    public float frequency = 1f;
    private Vector3 newLocation;
    // Start is called before the first frame update
    void Start()
    {
        newLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;

        time += Time.deltaTime;

        if(!moving && time >= frequency)
		{
            time = 0.0f;
            moveDirection = directionTowardsPlayer();
            newLocation = transform.position + moveDirection;
            //transform.position = Vector3.MoveTowards(transform.position, moveDirection, Time.deltaTime * moveSpeed);
            
            //Fix this. Don't let it ever try to collide with a collider
            /*if(player.GetComponent<Collider>.bounds.Contains(newLocation))
            {
                print("point hits collider");
            }*/

            transform.position += moveDirection;
            moving = true;
        }
        
        if (transform.position == newLocation)
        {
            moving = false;
        }

        /*if(moving)
		{
            timeToMoveCounter -= Time.deltaTime;
            //myRigidbody.velocity = moveDirection;
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, Time.deltaTime * moveSpeed);
            if(timeToMoveCounter < 0f)
			{
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
			}
		}
        else
		{
            timeBetweenMoveCounter -= Time.deltaTime;
            //myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
			{
                moving = true;
                timeToMoveCounter = timeToMove;
                moveDirection = directionTowardsPlayer();
			}
		}*/
    }

    Vector3 directionRandom()
	{
        return new Vector3(Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, moveSpeed)), Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, moveSpeed)), 0f);
    }

    Vector3 directionTowardsPlayer()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        //Debug.Log(dir.x + " " + dir.y);
        if(dir.x > 0.3)
		{
            moveDirection += Vector3.right;
		}
        else if(dir.x < -0.3)
		{
            moveDirection += Vector3.left;
		}

        if (dir.y > 0.3)
        {
            moveDirection += Vector3.up;
        }
        else if (dir.y < -0.3)
        {
            moveDirection += Vector3.down;
        }

        //Debug.Log("Dir.x: " + dir.x + ", Dir.y: " + dir.y);
        return dir;
    }
}