using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private CharacterController2D Player;

    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;

    public bool doorOpen, waitingToOpen;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingToOpen)
        {
            if(Vector3.Distance(Player.followingKey.transform.position, transform.position)< 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                theSR.sprite = doorOpenSprite;

                Player.followingKey.gameObject.SetActive(false);

                Player.followingKey = null;
            }
        }   
        if (doorOpen && Vector3.Distance(Player.transform.position, transform.position) < 1f && Input.GetAxis("Vertical") > 0.1f)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(Player.followingKey != null)
            {
                Player.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
