using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScript : MonoBehaviour, IPointerClickHandler
{
    //used to determine type button
    public int buttonType = 0;

    //How to use buttonType:
    //0 is used to enter game --- CHANGE STRING TO THE RELEVANT SCENE WHEN IT IS IMPLEMENTED, ALSO NEED TO MESS WITH BUILD SETTINGS
    //1 is used to exit the game
    //2 is used to open the credits (discussion with artists)

    //activate when a button clicks
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //if you are the open game button
        if(buttonType == 0)
        {
            //if you have been left clicked
            if(pointerEventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Start Game button pushed");
                //replace the string with the actual gameScene when we have decided on it
                SceneManager.LoadScene("MattScene");
            }

        }

        //if you are the button to close the game
        if(buttonType == 1)
        {
            //if you have been left clicked
            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Exit Game button pushed");
                //exit application
                Application.Quit();
            }

            
        }

        //if you are the button to open credits
        if (buttonType == 2)
        {
            //if you have been left clicked
            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                //display credits or something?
                Debug.Log("AAAAAAAAAAAAAAAAAA");
            }


        }

    }
}
