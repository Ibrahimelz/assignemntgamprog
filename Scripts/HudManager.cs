using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text scoreLabel;
    public Text timeLabel;
    float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
        elapsedTime = 0f;
        //timeLabel.text = "yoo";
    }

    // Update is called once per frame
    public void Refresh()
    {
        scoreLabel.text = "Score: " + GameManager.instance.score;
        
    }

    //dont work ;(
    void Update()
    {
      
        elapsedTime += Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);

        string timeText = string.Format("{0:D1}:{1:D2}.{2:D3}",
            timeSpan.Minutes,
            timeSpan.Seconds,
            timeSpan.Milliseconds);

        
        timeLabel.text = "Time: " + timeText;
    }
}
