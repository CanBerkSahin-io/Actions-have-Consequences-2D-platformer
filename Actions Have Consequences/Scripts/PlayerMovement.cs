using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;
	public AudioSource jumpSound;
	public ParticleSystem footsteps;
	private ParticleSystem.EmissionModule footEmission;


	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private float speed = 10;
	private float boostTimer = 0;
	private bool boosting = false;
	
	
	public void Start ()
	{
		speed = 10;
		boostTimer = 0;
		boosting = false;

	}
	// Update is called once per frame
	public void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}


	

	public void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
