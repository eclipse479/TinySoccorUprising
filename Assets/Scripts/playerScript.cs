using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public bool WASD = false;
    public float speed = 100;
    public float angularDrag = 1.0f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.angularDrag = angularDrag;
    }

    // Update is called once per frame
    void Update()
    {
        if (!WASD)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector3(-speed, 0, 0) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector3(speed, 0, 0) * Time.deltaTime);
            }
        }
        else if(WASD)
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

        if (Input.GetKey(KeyCode.Space))
        {
           rb.AddTorque(transform.right * -10);
        }
    }
}
