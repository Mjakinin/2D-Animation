using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllerx : MonoBehaviour
{
    public Transform player;
    public float offsetX;
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        float targetX = player.position.x * offsetX;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
