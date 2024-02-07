using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BackgroundTrigger : MonoBehaviour
{
    public BackgroundController bgcontroller;
    public CinemachineVirtualCamera virtualCamera;

    public float targetOrthoSize = 8f;
    public float transitionTime = 1f;

    private bool transitioning = false;
    private float initialOrthoSize = 0f;
    private float transitionStartTime = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bgcontroller.enabled = true;

            if (virtualCamera != null && !transitioning)
            {
                initialOrthoSize = virtualCamera.m_Lens.OrthographicSize;
                transitionStartTime = Time.time;
                transitioning = true;
            }
        }
    }

    private void Update()
    {
        if (transitioning && virtualCamera != null)
        {
            float t = (Time.time - transitionStartTime) / transitionTime;
            float currentOrthoSize = Mathf.Lerp(initialOrthoSize, targetOrthoSize, t);
            virtualCamera.m_Lens.OrthographicSize = currentOrthoSize;

            if (t >= 1f)
            {
                transitioning = false;
            }
        }
    }
}
