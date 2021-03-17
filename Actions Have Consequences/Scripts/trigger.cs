using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{


    public bool check;

    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform spawnPoint2;

     
    // Start is called before the first frame update
    void Start()
    {
        check = false;


    }

    // Update is called once per frame
    void Update()
    {
        

    }

     void OnTriggerEnter2D(Collider2D Collision)
        {
            if(Collision.gameObject.tag == "Player")
            {
                check = true;
                Debug.Log("Checkpoint true");
                
                
            }
            else
            {
                check = false;
                Debug.Log("checkpoint false");
               
            }
        }
    
}
