using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFollow : MonoBehaviour
{
    public float keySpeed;

    public Transform followTarget;

    public GameObject keyActive;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Keys key = FindObjectOfType<Keys>();
            key.numOfKeys++;

            keyActive.SetActive(false);
        }
    }
}
