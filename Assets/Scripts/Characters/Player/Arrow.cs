using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 3.0f;
    float arrowRotation;
    Vector3 movementDirection;
    public GameObject weapon;
    public float additionalDamage;
    public GameObject upgradedStats;
    // Start is called before the first frame update
    void Start()
    {
        upgradedStats = GameObject.FindGameObjectsWithTag("Stats")[0];
        //Debug.Log(arrowRotation);
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(arrowRotation);
        //Debug.Log(transform.position);
        transform.position += movementDirection * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag == "Boss")
        {
            Debug.Log("Enemy hit" + (weapon.GetComponent<BaseWeapon>().attackDamage + additionalDamage + upgradedStats.GetComponent<Stats>().upgradedDamage));
            col.GetComponent<EnemyHealthManager>().LoseHealth(weapon.GetComponent<BaseWeapon>().attackDamage + additionalDamage + upgradedStats.GetComponent<Stats>().upgradedDamage);
            Destroy(gameObject);
        }
    }

    public void SetRotation(float rot)
	{
        arrowRotation = rot;
        //Debug.Log(arrowRotation);
        if (arrowRotation == 135.0f)
        {
            movementDirection = new Vector3(1.0f, 0.0f, 0.0f);
        }
        else if (arrowRotation == -45.0f)
        {
            movementDirection = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        else if (arrowRotation == 45.0f)
        {
            movementDirection = new Vector3(0.0f, -1.0f, 0.0f);
        }
        else if (arrowRotation == 225.0f)
        {
            movementDirection = new Vector3(0.0f, 1.0f, 0.0f);
        }
        else
        {
            movementDirection = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
