using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");

        target = player.transform.position;
        print(target);
    }
    Vector3 target;
    bool explode = false;
    // Update is called once per frame
    void Update()
    {
        if (transform.position == target)
        {
            explode = true;
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(20, 20);
            StartCoroutine(ExampleCoroutine());

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);

        }


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        print("triggered");
        if (col.gameObject.name.Contains("Sprite"))
        {
            if (explode)
            {
                //GameObject.Find("Health Bar").GetComponent<PlayerHealthController>().LoseHealth(10);

                print("took explosion damage");
            }
            else
            {
                GameObject.Find("Player Health Bar").GetComponent<PlayerHealthController>().LoseHealth(5);

                print("took direct damage");
            }

        }

    }
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}