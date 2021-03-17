using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleOnCollider : MonoBehaviour
{
   	public GameObject particle;
    public AudioSource checkPointSound;
    public bool doOnce; 
    public GameObject text;  
    public GameObject collider1;
    public GameObject collider2;
    
    [SerializeField] private Animator checkpoint;



    void Start()
    {
        particle.SetActive(false);
        doOnce = false;
        text.SetActive(false);

    }

    void Awake()
    {
        //collider2.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //collider2.SetActive(true);
            if (doOnce == false)
            {
                {
                    //collider1.SetActive(false);
                    particle.SetActive(true);
                    checkPointSound.Play();
                    text.SetActive(true);
                    checkpoint.SetBool("checkpoint", true);
                    doOnce = true;
                    StartCoroutine(WaitForSeconds());
                }
            }
        }
    }
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
