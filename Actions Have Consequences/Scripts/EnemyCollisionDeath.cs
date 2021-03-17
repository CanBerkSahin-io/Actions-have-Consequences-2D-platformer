using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDeath : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public AudioSource deathSound;
    public Health healthScript;
    public Scoring scoreScript;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            Scoring.theScore -= 2;
            //col.transform.position = spawnPoint.position;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
            deathSound.Play();
            healthScript.health -=1;
        }

    }
}
