using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public static Thief instance;
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;

    public Transform player;

    public bool isFlipped = false;

    public int attackDamage = 20;
    public float attackRange = 1f;
    float nextAttackTime = 0f;
    public Transform attackPoint;
    public LayerMask hero;

    public Vector3 defaultCentralPos = new Vector3(30f, 0f, 0f);
    public Vector3 centralPos;
    public bool dead = false;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        InitThief();
    }

    public void InitThief() {
        currentHealth = maxHealth;
        dead = false;
        centralPos = defaultCentralPos;
        transform.position = centralPos;
        GetComponent<Collider2D>().enabled = true;
        gameObject.SetActive(true);
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

        GetComponent<Collider2D>().enabled = false;
        dead = true;
        StarManager.instance.FillStar();
    }



    public void Attack()
    {
        Collider2D[] hitHero = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hero);

        if (Time.time >= nextAttackTime)
        {
            foreach (Collider2D hero in hitHero)
            {
                hero.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1.5f;
            }
        }
    }
    
    void Update() {
        
        if(gameObject.activeInHierarchy) {
            transform.position -= new Vector3(Time.deltaTime * ObstacleController.instance.obstacleVelocity, 0f, 0f);
        }
        if(gameObject.activeInHierarchy) {
            centralPos -= new Vector3(Time.deltaTime * ObstacleController.instance.obstacleVelocity, 0f, 0f);
        }
    }

    void OnBecameInvisible() {
        if(!dead) {
            GameLogic.instance.GameOver("You let a thief escape");
            return;
        }
        
        gameObject.SetActive(false);
        dead = false;
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
}