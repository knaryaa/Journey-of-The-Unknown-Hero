using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject colliderBoss;
    public GameObject bossObject;
    public float boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossObject.GetComponent<EnemyHealth>().currentHealth == 0)
        {
            colliderBoss.SetActive(false);
        }
    }
}
