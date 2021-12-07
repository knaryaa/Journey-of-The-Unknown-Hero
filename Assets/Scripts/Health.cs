using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public Animator animator;
    public Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        Debug.Log("Hurt");

        if (health <= 0)
        {
            Die();
        }
            
    }

    void Die()
    {
        Debug.Log("Dead");
        animator.SetBool("Death", true);
        GetComponent<PrototypeHero>().enabled = false;
    }
}
