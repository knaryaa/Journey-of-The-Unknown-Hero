using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private PrototypeHero thePlayer;

    public Animator anim;

    public bool doorOpen;

    public int requiredKeys;

    public float doorTime, doorIntTime;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PrototypeHero>();

        doorIntTime = doorTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            anim.SetTrigger("Door");

            doorIntTime -= Time.deltaTime;

            if (doorIntTime < 0)
            {
                anim.SetTrigger("Door");

                foreach (Collider2D c in GetComponents<Collider2D>())
                {
                    c.enabled = false;
                }
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Keys key = FindObjectOfType<Keys>();

            if (key.numOfKeys == requiredKeys)
            {
                doorOpen = true;
                
                key.numOfKeys--;
            }
            //else
            {

            }
        }
    }
}