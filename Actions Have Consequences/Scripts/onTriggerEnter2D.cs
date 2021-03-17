using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerEnter2D : MonoBehaviour
{
    public GameObject particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            particleSystem.SetActive(true);
            Destroy(gameObject);
        }
    }

}
