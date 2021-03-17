using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;

    public GameObject projectile;



    // Update is called once per frame
    void Update()
    {
        //get input from player
        if (Input.GetMouseButtonDown(0))
        {
            //spawn a projectile
            Instantiate(projectile, firePosition.position, firePosition.rotation);
        }

        //where to spawn the projectile
    }
}
