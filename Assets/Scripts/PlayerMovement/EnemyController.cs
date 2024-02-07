using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float rechts;
    public float links;

    private bool rückstoß;

    private Vector3 rotation;

    void Start()
    {
        rechts = transform.position.x + rechts;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {   
        // < >
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x < links)
        {
            transform.eulerAngles = rotation;
        }
        if(transform.position.x > rechts)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
        }
    }
}
