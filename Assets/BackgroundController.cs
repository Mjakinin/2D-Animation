using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundController : MonoBehaviour
{
    public Transform player;
    public float offsetY;
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        float targetY = player.position.y * offsetY;
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

