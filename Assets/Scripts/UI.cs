using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text TimerText;
    public float maxTimer;

    //private variables
    [HideInInspector]
    public float player1Score;
    [HideInInspector]
    public float player2Score;
    private float minutes;
    private float seconds;
    void Start()
    {
        minutes = Mathf.Floor(maxTimer / 60);
        seconds = maxTimer % 60;

       
    }

    // Update is called once per frame
    void Update()
    {
        string displayedSeconds = seconds.ToString("F0");
        if (seconds >10)
        TimerText.text = minutes.ToString() + " : " + displayedSeconds;
        else if(seconds < 10)
        TimerText.text = minutes.ToString() + " : 0" + displayedSeconds;

        seconds -= Time.deltaTime;
        if(seconds<0)
        {
            if(minutes > 0)
            {
                seconds = 59;
                minutes--;
            }
        }

        player1ScoreText.text = "Score: " + player1Score.ToString();
        player2ScoreText.text = "Score: " + player2Score.ToString();
    }
}
