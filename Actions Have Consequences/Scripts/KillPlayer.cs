using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{
    public static int deathCount;
    public GameObject deathText;
    [SerializeField] Transform spawnPoint;
    public AudioSource deathSound;
    


    void Start()
    {
        deathCount = 0;
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player"))
            col.transform.position = spawnPoint.position;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
            deathSound.Play();
            KillPlayer.deathCount += 1;
            deathText.GetComponent<Text>().text = "Deaths: " + deathCount;

    }
 
}
