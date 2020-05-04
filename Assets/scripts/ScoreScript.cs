using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            scoreAmount++;
            Destroy(other.gameObject);
            //activeBalls--;
        }
    }
}
