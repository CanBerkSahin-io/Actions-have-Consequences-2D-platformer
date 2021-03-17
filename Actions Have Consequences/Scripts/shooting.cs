using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPos;

    public float fireRate = 0.5f;
    float nextFire = 0.0f;
	public AudioSource fireballSFX;
	public ParticleSystem fireballRightSFX;
	public ParticleSystem fireballLeftSFX;
    public CharacterController2D controller;





    // Start is called before the first frame update
    void Start()
    {
        fireballRightSFX.Stop();
		fireballLeftSFX.Stop();


        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }


        
    }

    void fire()
    {
        bulletPos = transform.position;
        if (CharacterController2D.m_FacingRight)
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


}
