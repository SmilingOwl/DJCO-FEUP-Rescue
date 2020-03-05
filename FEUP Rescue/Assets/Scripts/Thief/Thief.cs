using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;

    public Transform player;

    public bool isFlipped = false;

    public int attackDamage = 20;
    public float attackRange = 1f;
    public Transform attackPoint;
    public LayerMask hero;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; 
        
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack()
    { 
        Collider2D[] hitHero = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hero);

        //make damage
        foreach (Collider2D hero in hitHero)
        {
            hero.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}