using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTriggerScene : MonoBehaviour
{

    public GameObject uiObject;
    public GameObject UIObjectHide;
    public GameObject UIObjectHide2;
    public GameObject UIObjectHide3;
    public GameObject UIObjectHide4;
    public GameObject UIObjectHide5;
    public GameObject UIObjectHidePanel;
    

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter2D (Collider2D player)    // collision with player
    {
        if (player.gameObject.tag == "Player")
            {
                uiObject.SetActive(true);
                Time.timeScale = 0f;  //
                //StartCoroutine("WaitForSec");   // calling wait for sec function down below.    
                UIObjectHide.SetActive(false);
                UIObjectHide2.SetActive(false);
                UIObjectHide3.SetActive(false);
                UIObjectHide4.SetActive(false);

                
                
            }

    }
        
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(4);
        Destroy(uiObject);
        Destroy(gameObject);
        SceneManager.LoadScene(2);
        Time.timeScale = 1f; // 

    }

}
