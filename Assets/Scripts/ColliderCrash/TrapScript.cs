using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TrapScript : MonoBehaviour
{
	public Animator animator;
    public PlayerMovement Player;
    public CharacterController2D CharacterController2D;


    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private Collider2D PlayerCrouchCollider;
    [SerializeField] private Collider2D SwordCollider;

    public bool isHurt = false;

    private CircleCollider2D mycol;

    void Start()
    {
        mycol = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col == PlayerCollider || col == PlayerCrouchCollider)
        {
            CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;

            if(mycol.transform.position.x <= PlayerCollider.transform.position.x)
            {
                CharacterController2D.KnockFromRight = false;
            }
            if(mycol.transform.position.x > PlayerCollider.transform.position.x)
            {
                CharacterController2D.KnockFromRight = true;
            }

            
            if(!isHurt)
            {
                Player.currentHealth -= 1;

                Player.healthBar.SetHealth(Player.currentHealth);
        
                if(Player.currentHealth < 1)
                {
                    SceneManager.LoadScene("Game Over");
                }

                animator.SetBool("IsHurt", true);
            
                isHurt = true;

                StartCoroutine(StopHurtAnimation());
            }
        }

        if(col == SwordCollider)
        {
            Destroy(gameObject);
        }

    }

    
    IEnumerator StopHurtAnimation()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsHurt", false);
        yield return new WaitForSeconds(0.2f);
        isHurt = false;

    }
}
