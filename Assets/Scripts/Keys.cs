using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public int numOfKeys;
    
    public Image[] keys;



    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < keys.Length; i++)
        {
            if (i < numOfKeys)
            {
                keys[i].enabled = true;
            }
            else
            {
                keys[i].enabled = false;
            }
        }
    }
}
