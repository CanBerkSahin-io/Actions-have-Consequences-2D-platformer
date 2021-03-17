using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    

    public int health;
    public int numOfHearts;
    [SerializeField] Transform spawnPoint;
    public AudioSource deathSound;

    public GameObject collider1;
    public GameObject collider2;

    public GameObject collideTrigger;
    public trigger triggerScript;
    [SerializeField] Transform spawnPoint2;

    public GameObject uiObject;
    public GameObject UIObjectHide;
    public GameObject UIObjectHide2;
    public GameObject UIObjectHide3;
    public GameObject UIObjectHide4;
    public GameObject UIObjectHide5;
    public GameObject UIObjectHide6;
    public GameObject UIObjectHide7;
    public GameObject UIObjectHide8;
    public GameObject UIObjectHide9;
    public GameObject UIObjectHide10;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void Start()
    {
        health = 5;
        numOfHearts =5;
        collider2.SetActive(false);
        triggerScript.check = false;

        uiObject.SetActive(false);

    }
    
    public void Update()
    {
        if(health > numOfHearts){
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health){
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
               hearts[i].enabled = false; 
            }
            
        }

        if(health <= 0)
        {
            killPlayer();
            
        }
    
    }

        
    
    public void killPlayer()
    {
        Debug.Log("Player is dead");
        //health = 5;
        //Application.LoadLevel(0);
        Time.timeScale = 0f;
        uiObject.SetActive(true);
        UIObjectHide.SetActive(false);
        UIObjectHide2.SetActive(false);
        UIObjectHide3.SetActive(false);
        UIObjectHide4.SetActive(false);                
        UIObjectHide5.SetActive(false);
        UIObjectHide6.SetActive(false);
        UIObjectHide7.SetActive(false);
        UIObjectHide8.SetActive(false);
        UIObjectHide9.SetActive(false);                
        UIObjectHide10.SetActive(false);
        

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(triggerScript.check == false)
            {
                health -= 1;
                CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
                deathSound.Play();
                col.transform.position = spawnPoint.transform.position;
            }
        }
        else
        {
            if(col.gameObject.tag == "Player" && triggerScript.check == true)
            {
                col.transform.position = spawnPoint2.transform.position;  
                CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
                health -= 1;
                deathSound.Play();
                
            }
        }
        
        
    }


}


