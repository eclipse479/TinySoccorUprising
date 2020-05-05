using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text TimerText;
    public Text WinnerText;
    public float maxTimer;
    public float timeAfterEnd = -5; //MUST BE A NEGATIVE NUMBER

    public GameObject BallSpawnerObject;
    public GameObject GoalOne;
    public GameObject GoalTwo;

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
        WinnerText.enabled = (false);
       
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

        //if the timer is less than zero, based on who has more points, display winner text
        if(seconds <= 0 && minutes <= 0)
        {
            //turn on winner text
            WinnerText.enabled = (true);

            //turn off timer text (so it doesnt display negative)
            TimerText.enabled = false;

            BallSpawnerObject.GetComponent<BallSpawner>().isOn = false;

            GoalOne.GetComponent<ScoreScript>().isActive = false;
            GoalTwo.GetComponent<ScoreScript>().isActive = false;

            //if the score is the same, its a draw
            if (player1Score == player2Score)
            {
                WinnerText.text = "Its a draw!";
            }

            //if player 1 has more points
            if(player1Score > player2Score)
            {
                WinnerText.text = "Player 1 Wins!";
            }

            //if player 2 has more points
            if (player2Score > player1Score)
            {
                WinnerText.text = "Player 2 Wins!";
            }

            //if the seconds are after time is up, are at value
            if(seconds < timeAfterEnd)
            {
                SceneManager.LoadScene("Title");
            }
        }

    }
}
