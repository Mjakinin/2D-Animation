using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{

    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private Collider2D PlayerCrouchCollider;

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col == PlayerCollider || col == PlayerCrouchCollider)
        {
            LevelManager.level += 1;
            SceneManager.LoadScene("Start");
        }

    }
}
