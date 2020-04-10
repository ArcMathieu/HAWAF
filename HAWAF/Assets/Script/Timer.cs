using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    public int desiredTimeInSeconds;
    public MainMenu loadingManager;
    public int gameOverSceneID;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes =  ((int)(desiredTimeInSeconds - t) / 60).ToString();
        string seconds = (((desiredTimeInSeconds)-t) % 60).ToString("f0");

        float minutesLeft = ((float)desiredTimeInSeconds - t)/60;

        timerText.text = minutes + " minutes " + seconds + " restantes";
        
        if(minutesLeft < 0)
        {
            SoundManager.PlaySound("fan");

            loadingManager.LoadScene(gameOverSceneID);
        }
    }
}
