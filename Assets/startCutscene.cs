using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PrototypeHero")
        {
            Debug.Log("hey!");
        }
    }
}