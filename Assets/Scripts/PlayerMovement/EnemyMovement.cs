using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//    <   >
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Geschwindigkeit des Enemies

    private bool movingRight = true; // bool um zu überprüfen ob Enemy nach rechts läuft

    void Update()
    {
        if (movingRight) // Wenn der Enemy nach rechts läuft
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Bewegung nach rechts
            transform.localScale = new Vector2(-1f, 1f); // Enemy umdrehen
        }
        else // Wenn der Enemy nach links läuft
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // Bewegung nach links
            transform.localScale = new Vector2(1f, 1f); // Enemy umdrehen
        }

        // Überprüfung, ob der Enemy den linken oder rechten Rand erreicht hat
        if (transform.position.x >= 5f)
        {
            movingRight = false; // Richtung ändern
        }
        else if (transform.position.x <= -5f)
        {
            movingRight = true; // Richtung ändern
        }
    }
}

