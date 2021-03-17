using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float velX = 9f;
    float velY = 0f;
    Rigidbody2D rb;
    public AudioClip fireballCollisionSFX;
    public AudioSource audioSource;
    public Health healthScript;

    


    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (velX, velY);
        Destroy(gameObject, 3f);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Scoring.theScore += 5;
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Ground"))
        {
            audioSource.Play(0);
            Destroy(gameObject);
        }
    }
}
