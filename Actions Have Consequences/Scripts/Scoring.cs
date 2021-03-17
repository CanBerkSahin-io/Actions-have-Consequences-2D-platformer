using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;
    public GameObject scoreTextEndLevel;
    public GameObject scoreTextCompleted;
    
    void Start()
    {
        theScore = 0;
        
    }
     
    void Update()
    {
            
            scoreText.GetComponent<Text>().text = "Score: " + theScore;
            scoreTextEndLevel.GetComponent<Text>().text = "SCORE: " + theScore;
            scoreTextCompleted.GetComponent<Text>().text = "SCORE: " + theScore;

        if (theScore <=0)
        {
            theScore = 0;
        }

    }

}
