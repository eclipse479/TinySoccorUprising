using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    //should be set to the ball prefab
    public GameObject spawnObject;

    public ParticleSystem particleEffect;

    //if it is turned on
    public bool isOn = true;

    //the amount of balls currently in play
    public int activeBalls = 0;

    //iterator used in the ball timer
    public float iterator = 0;

    public float ballSpawnTimer = 5;

    public float ballSpawnTimerMin = 2;

    public float ballSpawnTimerMax = 6;

   
    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            //if there are no balls, spawn one in
            if(activeBalls == 0)
            {
                Instantiate(spawnObject, this.transform);
                particleEffect.Play();
                activeBalls++;
            }

            iterator += Time.deltaTime;

            //once every few seconds spawn a ball
            if(iterator > ballSpawnTimer)
            {
               //create new ball
               Instantiate(spawnObject, this.transform);
               particleEffect.Play();

                //add a new ball to the count
                activeBalls++;

               //update the iterator
               iterator -= ballSpawnTimer;

               //make the new timer a random number in the range (var 1 is inclusive, var 2 is exclusive)
               ballSpawnTimer = Random.Range(ballSpawnTimerMin, (ballSpawnTimerMax + 1));
            }


        }

        //if(!isOn && activeBalls != 0)
        //{
        //    //for each ball child that exists, destroy it
        //    foreach(Transform ballObject in this.transform)
        //    {
        //        Destroy(ballObject.gameObject);
        //        activeBalls--;
        //    }
        //}


    }
}
