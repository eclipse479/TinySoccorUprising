using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class playerScriptV2 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    private bool returnRotation = false;
    bool secondSlerp = false;
    public bool WASD = false;

    public float speed = 100;
    public float rotateSpeed = 1;
    public float kickSpeed = 1;

    public float angularDrag = 1.0f;

    float timeTillBack = 0;

    public float buildSpeed = 2.0f;
    private float built;
    public float maxBuilt = 120;

    private float returnTimer = 0;

    private Quaternion start = new Quaternion(0,0,0,1);
    private Quaternion kickEnd = new Quaternion(0, 0, 0, 1);
    private Quaternion kickMid = new Quaternion(0, 0, 0, 1);
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.angularDrag = angularDrag;
        returnRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        //these cannot occur while object is returning to 0 rotation
        if (Input.GetKey(KeyCode.Space) && !returnRotation) // while space is down
        {
            built += buildSpeed;
            if(built > maxBuilt)
            {
                built = maxBuilt;
            }
            else
            {
                gameObject.transform.Rotate(new Vector3(buildSpeed, 0, 0));
            }
            start = gameObject.transform.rotation;

           
        }
        else if(Input.GetKeyUp(KeyCode.Space)) // when space is released
        {
            //calculates the points to slerp to when the space bar is released
            //------------ sets up variables for use ------------
            secondSlerp = false;
            returnRotation = false;
            returnTimer = 0;
            timeTillBack = 0;
            //---------------------------------------------------
            //gets the start/end points for the 2 slerps needed
            float startPoint = built;
            float endPoint = built * -0.75f;
            float distance = startPoint - endPoint;
            // built > 0 at all times   &&   start point > |end point| at all times
            float halfWayPoint = distance * 0.5f; // when the slerps need to change

            //the 2 points to slerp to
            kickMid = Quaternion.Euler(startPoint - halfWayPoint, 0, 0);
            kickEnd = Quaternion.Euler(endPoint ,0,0);
        }
        else if(!Input.GetKey(KeyCode.Space) && !returnRotation) // while space is up
        {
           //when the space bar is up slerp to the half way point
            if(timeTillBack<1)
            {
                timeTillBack += Time.deltaTime * 2 * kickSpeed; // twice as fast as there are 2 slerps
            }

            //will either go from start to middle or middle to end but will do both so that it will go the correct direction
            if (!secondSlerp)
            {
                gameObject.transform.rotation = Quaternion.Slerp(start, kickMid, timeTillBack); // first slerp
            }
            else if (secondSlerp)
            {
                 gameObject.transform.rotation = Quaternion.Slerp(kickMid, kickEnd, timeTillBack); // second slerp
            }


            if (timeTillBack > 1)
            {
                start = gameObject.transform.rotation;
                if (secondSlerp)
                {
                    returnRotation = true;
                }
                else if (!secondSlerp)
                {
                    secondSlerp = true;
                    timeTillBack = 0;
                }
            }
        }
        if (returnRotation)
        {
            returnTimer += Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Lerp(start, new Quaternion(0, 0, 0, 1), returnTimer);
            if (returnTimer > 1)
            {
                returnRotation = false;
                //secondSlerp = false;
                built = 0;
            }
        }
        Debug.Log(built);
    }

    private void FixedUpdate()
    {
        if (!WASD)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(-speed, 0, 0));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(speed, 0, 0));
            }
        }
        else if (WASD)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector3(-speed, 0, 0) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(speed, 0, 0) * Time.deltaTime);
            }
        }
    }
}
