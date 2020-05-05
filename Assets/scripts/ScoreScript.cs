using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //public static int scoreAmount;
    //false for player one, true for player two
    public bool playerGoal;
    //public TextMeshProUGUI scoreText;
    public GameObject ballSpawnerObject;
    public GameObject GuiCanvas;
    public ParticleSystem ScoreParticles;
    public bool isActive = true;
   

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GetComponent<Text>();
        //scoreAmount = 0;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    scoreText.text = "Score: " + scoreAmount;

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball") && isActive)
        {
            //scoreAmount++;

            Destroy(other.gameObject);

            //false for player one, true for player 2
            if(!playerGoal)
            {
                GuiCanvas.GetComponent<UI>().player1Score++;
                ScoreParticles.Play();
            }
            else
            {
                GuiCanvas.GetComponent<UI>().player2Score++;
                ScoreParticles.Play();
            }

            ballSpawnerObject.GetComponent<BallSpawner>().activeBalls--;
               
        }
    }
}
