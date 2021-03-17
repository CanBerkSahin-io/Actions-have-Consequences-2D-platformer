using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;
	public AudioSource jumpSound;
	public Transform keyFollowPoint;
	public key followingKey;
	public ParticleSystem footsteps;
	private ParticleSystem.EmissionModule footEmission;
	public PlayerMovement movement;
					// A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	public static bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public GameObject bulletToRight, bulletToLeft;

    Vector2 bulletPos;

    public float fireRate = 0.5f;
    float nextFire = 0.0f;
	public AudioSource fireballSFX;
	public ParticleSystem fireballRightSFX;
	public ParticleSystem fireballLeftSFX;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	GameObject DeathCollider;
	private float speed;
	private float boostTimer;
	private bool boosting;
	public Health healthScript;
	public AudioSource deathSound;

	public void Start()
	{
		//Time.timeScale = 1f; 
		footEmission = footsteps.emission;
		fireballRightSFX.Stop();
		fireballLeftSFX.Stop();

		speed = 10;
		boostTimer = 0;
		boosting = false;

		healthScript.health = 5;
		healthScript.numOfHearts =5;
		m_FacingRight = true;

	}

	void Update()
	{
		//show footstep effect
		if (Input.GetAxisRaw("Horizontal") != 0 && m_Grounded)
		{
			footEmission.rateOverTime = 35f;
		}
		else
		{
			footEmission.rateOverTime = 0f;
		}

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //fire();
        }
	
		if (boosting)
		{
			boostTimer += Time.deltaTime;
			if(boostTimer >= 12)
			{
				speed = 10;
				boostTimer = 0;
				boosting = false;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "SpeedBoost")
		{
			boosting = true;
			speed = 19;
			healthScript.health -=1;
			deathSound.Play();
			CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
			Destroy(other.gameObject);
		}
	}


	

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * speed, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			jumpSound.Play();
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/*void fire()
    {
        bulletPos = transform.position;
        if (m_FacingRight)
        {
            bulletPos += new Vector2 (+0.5f, 0.7f);
            Instantiate (bulletToRight, bulletPos, Quaternion.identity);
			fireballSFX.Play();
			fireballRightSFX.Play();        
        }else
        {
            bulletPos += new Vector2 (-0.5f, 0.7f);
            Instantiate (bulletToLeft, bulletPos, Quaternion.identity * Quaternion.Euler (0,0,-180)); 
			fireballSFX.Play();
			fireballLeftSFX.Play();    
        }
    }
	*/
}