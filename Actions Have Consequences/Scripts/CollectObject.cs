using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public AudioSource collectSound;

    public GameObject UI;
    public GameObject gem;

    private bool hasCollide = false;

    public void start()
     {
        UI.SetActive(false);
     }
    public void OnTriggerEnter2D(Collider2D Player)
    {
        if(hasCollide == false)//   if the player has collided before then do not apply the code below, if not collided before, apply those.
            {
                if (Player.gameObject.tag == "Player")
                    {
                    hasCollide = true;//
                    UI.SetActive(true);
                    collectSound.Play();
                    Scoring.theScore += 1;
                    Destroy(gem);

            }
            
    }

}
}
