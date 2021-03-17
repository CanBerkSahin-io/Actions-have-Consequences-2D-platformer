using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;
    
    void Start()
    {
        theScore = 0;
        
    }
     
    void Update()
    {
            
            scoreText.GetComponent<Text>().text = "" + theScore;



    }

}
