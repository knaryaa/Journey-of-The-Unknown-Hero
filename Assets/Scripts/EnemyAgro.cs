using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    public float attackCooldown = 0;
    public PrototypeHero hero;

    [SerializeField]
    Transform PrototypeHero;

    public float walkRange;

    [SerializeField]
    float hitRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    Animator anim;

    public GameObject Attack;

    public Transform attackPoint;

    public float cooldownIntTimer;
    public float cooldownTimer;

    public bool cooling;
    public bool attackMode;
    public bool walking;

    

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cooldownIntTimer = cooldownTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        float distToPlayer = Vector2.Distance(transform.position, PrototypeHero.position);

        if (distToPlayer < hitRange)
        {
            InHitRange();
        }
        else if (distToPlayer < walkRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            ChasePlayer();
            
        }
        else
            StopChasePlayer();

        Cooldown();

       if (anim.GetBool("Flip"))
            Flip();
    }

    private void ChasePlayer()
    {

        if (anim.GetBool("isDead") == true)
        {

        }
        else if (!anim.GetBool("Attack"))
        {
            if (transform.position.x < (PrototypeHero.position.x - 0.4f))
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
                
                anim.SetBool("Walk", true);
            }
            else if (transform.position.x > (PrototypeHero.position.x + 0.4f))
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                
                anim.SetBool("Walk", true);
            }
            else
            {
                StopChasePlayer();
            }
        }
        anim.SetBool("Flip", true);
    }
    private void StopChasePlayer()
    {
        
        rb2d.velocity = Vector2.zero;
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
    }
    private void InHitRange()
    {
        
        if (cooling)
        {
            anim.SetBool("Flip", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", true);
            cooling = false;
        }
    }
    void Cooldown()
    {
        
        if (cooldownTimer <= 0)
        {
            cooling = true;
            
            

        }
    }
    public void TriggerCooling()
    {
        cooling = false;
        anim.SetBool("Attack", false);
        cooldownTimer = cooldownIntTimer;
        

    }
    public void IdleFlip()
    {
        anim.SetBool("Flip", true);
    }
    public void NotIdleFlip()
    {
        anim.SetBool("Flip", false);
    }
    public void HitDamage()
    {
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(25);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!hero.invincible)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().TakeDamage(1);
                hero.invincible = true;
            }
        }

    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x < PrototypeHero.position.x)
        {
            rotation.y = 0;
        }
        else if(transform.position.x > PrototypeHero.position.x)
        {
            rotation.y = 180;
        }

        transform.eulerAngles = rotation;
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
