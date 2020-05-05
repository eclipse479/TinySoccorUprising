using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ball : MonoBehaviour
{
    private Rigidbody rb;

    public int randomNumberMin = -20;

    public int randomNumberMax = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        int randomX = Random.Range(randomNumberMin, randomNumberMax + 1);

        int randomZ = Random.Range(randomNumberMin, randomNumberMax + 1);

        rb.AddForce(new Vector3(randomX, 0, randomZ) ,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
