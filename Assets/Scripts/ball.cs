using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, -10) ,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
