using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    public Text timerText;    // declaring timertext
    public Text timerTextEndLevel;  // declaring timer text for end of level screen
    public Text timerTextCompleted;  // declaring timer text for end of level screen
    private float startTime;     // start time
    private bool finnished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;     // when the timer is first called which is at the start of the level, starts timer.
    }

    // Update is called once per frame
    void Update()                                            
    {
    
        float t = Time.time - startTime;                  // t = time.time - start time to get current time, this is called throughout the playthrough

        string minutes = ((int) t / 60).ToString();    // the timer will have minutes and seconds, to get the minutes, the t will have to be divided by 60 and display as string.
        string seconds = (t % 60).ToString("f2");     // to get the seconds the t will have to be % of 60 and displayed as string.

        timerText.text = minutes + ":" + seconds;      // the timertext ui game object will include the minutes and seconds variables which is constantly updating and changing on screen.
        timerTextEndLevel.text = minutes + ":" + seconds; //timerTextEndLevel.text = minutes + ":" + seconds; // the timer text end level ui game object will also include the minutes and seconds variables which is constantly updating and changing on screen.
        timerTextCompleted.text = minutes + ":" + seconds; //timerTextEndLevel.text = minutes + ":" + seconds; // the timer text end level ui game object will also include the minutes and seconds variables which is constantly updating and changing on screen.

    void finnish()
    {
        finnished = true;
        
    }

}
}

