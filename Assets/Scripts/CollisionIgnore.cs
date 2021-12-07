using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{

    public GameObject[] enemy;

    // Start is called before the first frame update
    void Awake()
    {

        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i = 0; i <= enemy.Length - 1; i++)
        {
            enemy[i].GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(enemy[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
