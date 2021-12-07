using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFollow : MonoBehaviour
{

    public float droneSpeed;

    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position, droneSpeed * Time.deltaTime);

        PrototypeHero thePlayer = FindObjectOfType<PrototypeHero>();


        followTarget = thePlayer.droneFollowPoint;

    }
}
