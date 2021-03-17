using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{   
    public Health healthScript;
    public AudioSource deathSound;
    public AudioSource healthSound;
    private float shootTimer;
    private bool shoot;



    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<shooting>().enabled = false;
        shootTimer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && GetComponent<shooting>().enabled == true)
        {
            
            GetComponent<shooting>().enabled = false;
            healthScript.health +=1;
            healthSound.Play();

        }

        if (shoot)
		{
			shootTimer += Time.deltaTime;
			if(shootTimer >= 25)
			{
				shootTimer = 0;
				GetComponent<shooting>().enabled = false;
			}
		}
        
    }


    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "ShootingObject")
		{

            GetComponent<shooting>().enabled = true;
            shoot = true;
			healthScript.health -=1;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
			deathSound.Play();
			Destroy(other.gameObject);
		}
	}



}
