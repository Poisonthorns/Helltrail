using UnityEngine;

public class EnemyMovementManager : MonoBehaviour
{
    public Transform player;

    /*public float moveSpeed;

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

    */


    public float speed;
    public Transform movePoint;
    public LayerMask collideables;
    public int powerLevel;
    private float nextMovement = 0.0f;
    public float movementInterval = 2.0f;
    void Start()
    {
        movePoint.parent = null;
        nextMovement = Random.Range(0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        if(Time.time > nextMovement)
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
            Vector3 moveDirection = directionTowardsPlayer();
            if(!Physics2D.OverlapCircle(movePoint.position + moveDirection, .2f, collideables))
            {
                movePoint.position += moveDirection;
            }
        }

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

    Vector3 directionRandom()
    {
        return new Vector3(Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, speed)), Mathf.Round(Random.Range(-1f, 1f)) * Mathf.Round(Random.Range(0, speed)), 0f);
    }
}