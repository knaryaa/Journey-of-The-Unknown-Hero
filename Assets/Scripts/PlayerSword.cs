using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public GameObject Attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>().TakeDamage(20);
            //Debug.Log("Hit");
        }
    }

    public void Attacking()
    {
        Attack.SetActive(true);
    }
    public void EndAttacking()
    {
        Attack.SetActive(false);
    }
}
