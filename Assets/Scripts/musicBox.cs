using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicBox : MonoBehaviour
{
    public bool firstScene = false;
    // Start is called before the first frame update
    private GameObject[] extra;
    private void Awake()
    {
        
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        extra = GameObject.FindGameObjectsWithTag("musicBox");
        if (extra.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
