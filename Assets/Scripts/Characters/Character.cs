using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    protected Transform movePoint;

    [SerializeField]
    protected LayerMask collideables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
    }

}
