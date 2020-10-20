using UnityEngine;

public class Soul : MonoBehaviour
{
    public GameObject stats;
    // Update is called once per frame
    void Update()
    {
        //Maybe a little animation?
    }

    void OnTriggerEnter2D(Collider2D col)
	{
        if(col.gameObject.name.Equals("Sprite"))
        {
            print("soul picked up");
            stats.GetComponent<Stats>().souls++;
            Destroy(gameObject);
        }
	}
}
