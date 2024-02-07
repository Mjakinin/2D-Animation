using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_skript : MonoBehaviour
{
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private Collider2D PlayerCrouchCollider;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col == PlayerCollider || col == PlayerCrouchCollider)
        {
            ScoreTextScript.coinAmount += 1;
            Destroy(gameObject);
        }

    }
}
