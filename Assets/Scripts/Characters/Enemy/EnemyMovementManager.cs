using UnityEngine;

public class EnemyMovementManager : MonoBehaviour
{
    public Transform player;

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;

    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        if (moving)
		{
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
			{
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
			}
		}
        else
		{
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
			{
                moving = true;
                timeToMoveCounter = timeToMove;
                moveDirection = directionTowardsPlayer();
			}
		}
    }

    Vector3 directionRandom()
	{
        return new Vector3(Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, moveSpeed)), Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, moveSpeed)), 0f);
    }

    Vector3 directionTowardsPlayer()
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
}