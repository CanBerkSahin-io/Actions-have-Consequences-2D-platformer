using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollection : MonoBehaviour
{

    public AudioSource healthSound;
    public Health healthScript;
    public GameObject healthIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			healthScript.health +=1;
			healthSound.Play();
			Destroy(healthIcon);
		}
	}
}
