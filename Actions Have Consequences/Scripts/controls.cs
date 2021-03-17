using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{

    public GameObject UI;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f; 
        UI.SetActive(true);
    }


    public void pressed()
    {
        UI.SetActive(false);
        Time.timeScale = 1f; 
    }
}
