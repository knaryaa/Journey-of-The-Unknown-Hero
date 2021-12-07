using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStart : MonoBehaviour
{
    public GameObject dialog;
    public GameObject image;

    public GameObject mainChar;
    public GameObject nextChar;

    public bool dialogEnd;
    public bool bossDialog;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && dialogEnd)
        {
            dialog.SetActive(true);
            image.SetActive(true);
            mainChar.SetActive(true);
            nextChar.SetActive(true);

            dialogEnd = false;
            if (bossDialog)
            {
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAgro>().walkRange = 20;
            }
        }
        
    }
}
