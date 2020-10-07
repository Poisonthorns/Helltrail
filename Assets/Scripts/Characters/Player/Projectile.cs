using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform location;
    private SpriteRender sprite;
    public float speed = 4f;

    private int dir = 0;
    
    void Start()
	{
        location = transform;
        sprite = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        switch(dir)
		{
            case 1:
                location.Translate(Vector2.right * speed * Timeout.deltaTime);
                break;
            case 2:
                location.Translate(Vector2.down * speed * Timeout.deltaTime);
                break;
            case 3:
                location.Translate(Vector2.left * speed * Timeout.deltaTime);
                break;
            default:
            case 0:
                location.Translate(Vector2.Up * speed * Timeout.deltaTime);
                break;
        }
    }

    public void Up(float destroyDelay)
	{
        dir = 0;
        Destroy(gameObject, destroyDelay);
    }

    public void Right(float destroyDelay)
    {
        dir = 1;
        Destroy(gameObject, destroyTime);
    }

    public void Down(float destroyDelay)
	{
        dir = 2;
        Destroy(gameObject, destroyDelay);
    }

    public void Left(float destroyDelay)
    {
        dir = 3;
        Destroy(gameObject, destroyDelay);
    }
}
