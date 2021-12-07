using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;

    public int maxHealth = 100;
    public int currentHealth;
    public float invincibleIntTimer;
    public float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        invincibleIntTimer = invincibleTime;
    }
    void Update()
    {
        invincibleIntTimer -= Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(invincibleIntTimer<=0)
        {
            if (col.gameObject.CompareTag("PlayerSword"))
            {
                TakeDamage(20);
                Debug.Log("Vurdu");
                invincibleIntTimer = invincibleTime;
            }
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hit");

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Dead");
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", false);
        animator.SetBool("isDead", true);

        GetComponent<EnemyAgro>().EndAttacking();
        rb2d.velocity = Vector2.zero;
        GetComponent<EnemyAgro>().enabled = false;
        GetComponent<CollisionIgnore>().enabled = false;
        this.enabled = false;
    }

}
