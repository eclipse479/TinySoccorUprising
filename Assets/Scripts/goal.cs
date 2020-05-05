using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    public float goalNumber;

    public Canvas canvas;
    private UI canvasUI;
    // Start is called before the first frame update
    void Start()
    {
        canvasUI = canvas.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ball")
        {
            if (goalNumber == 1)
            {
                canvasUI.player1Score += 1;
                Debug.Log(canvasUI.player1Score);
            }
            else if (goalNumber == 2)
            {
                canvasUI.player2Score += 1;
                Debug.Log(canvasUI.player2Score);
            }
        }
    }
}
