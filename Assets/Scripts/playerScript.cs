using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-100, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(100, 0, 0) * Time.deltaTime);
        }
    }
}
