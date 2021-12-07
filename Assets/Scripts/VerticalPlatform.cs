using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            waitTime = 0.5f;
            effector.rotationalOffset = 180;
        
        }
        else if(Input.GetKey(KeyCode.Space) || waitTime <= 0)
        {
            effector.rotationalOffset = 0;
        }
        else if(waitTime>=0)
        {
            waitTime -= Time.deltaTime;
        }

    }
}
