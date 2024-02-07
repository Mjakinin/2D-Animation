using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public Healthbar healthBar;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	public bool jump = false;
	public bool crouch = false;

	public bool shield = false;

	public bool stopHit = false;
	public bool hit = false;
	public bool stophitc = false;

	public int maxHealth = 10;
	public int currentHealth;

	public bool climb = false;
	

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if(shield)
		{
			horizontalMove /= 3f;
		}

		

		if (Input.GetButtonDown("Jump"))
		{

			jump = true;
			animator.SetBool("IsJumping", true);


		}

		if(animator.GetBool("IsJumping") && animator.GetBool("IsHitting"))
		{
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsHitting", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}


		if(animator.GetBool("IsHurt")){
			hit = false;
			animator.SetBool("IsHitting",false);
		}


		if (Input.GetButtonDown("Shield"))
		{
			shield = true;
			animator.SetBool("IsShielding", true);
		}
		else if(Input.GetButtonUp("Shield"))
		{
			animator.SetBool("IsShielding", false);
			shield = false;
		}


		if(!animator.GetBool("IsHurt") && animator.GetBool("IsShielding"))
		{
			shield=true;
		}

		if(jump || crouch || animator.GetBool("IsJumping") || animator.GetBool("IsHurt"))
		{
			shield = false;
		}

		if(animator.GetBool("IsShielding") && animator.GetBool("IsHitting"))
		{
			shield = false;
		}


		if (Input.GetButtonDown("Hit"))
    	{
        	animator.SetBool("IsHitting", true);
    	}
		if(stopHit)
		{
			animator.SetBool("IsHitting", false);
		}

		if(animator.GetBool("IsHitting") && animator.GetBool("IsCrouching"))
		{
			if(stophitc)
			{
				animator.SetBool("IsHitting", false);
			}
		}

		if(animator.GetBool("IsClimbing"))
		{
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsShielding", false);
			animator.SetBool("IsCrouching", false);
			animator.SetBool("IsHurt", false);
			shield = false;
			jump = false;
			crouch = false;
			hit=false;
		}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character

		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, hit, shield);
		jump = false;
		

		
	}
}
