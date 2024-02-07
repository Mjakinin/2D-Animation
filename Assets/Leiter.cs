using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leiter : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    public PlayerMovement Player;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Update()
    {  
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ladder") && !Player.hit)
        {
            isLadder = true;
            animator.SetBool("IsClimbing", true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("IsClimbing", false);
        }
    }
}
