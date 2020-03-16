using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public HeroController2D controller;

    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    
    bool jump = false;
    bool crouch = false;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 50;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    public Behaviour halo;
    public static PlayerMovement2D instance;

    void Awake() {
        instance = this;
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPos.x < 0 && !GameLogic.instance.HasGameEnded()) {
            GameLogic.instance.GameOver("You lost the thieves!");
            return;
        }
        //RUN
        float runSpeedAux = runSpeed;
        if(GameLogic.instance.isSpeeding()) {
            runSpeedAux *= 2;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if(horizontalMove < 0) {
            horizontalMove *= (runSpeedAux + 11f * 4);
        } else {
            horizontalMove *= runSpeedAux;
        }
        if(GameLogic.instance.HasGameEnded())
        {
            horizontalMove = 0;
        }
        
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        //JUMP
        if (Input.GetButtonDown("Jump") && !GameLogic.instance.HasGameEnded())
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        //ATTACK
        if (Time.time >= nextAttackTime && !GameLogic.instance.HasGameEnded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
        if(horizontalMove == 0 && screenPos.x >= 30 + GetComponent<SpriteRenderer>().bounds.size.x) {
            gameObject.transform.position -= new Vector3(ObstacleController.instance.obstacleVelocity * Time.deltaTime, 0f, 0f);
        }
    }

    public void Attack()
    {
        //plays animation
        animator.SetTrigger("Attack");

        //detects enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //make damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Thief>().TakeDamage(attackDamage);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPos.x < 60 + GetComponent<SpriteRenderer>().bounds.size.x && horizontalMove < 0
            || screenPos.x > Screen.width-horizontalMove - GetComponent<SpriteRenderer>().bounds.size.x/2.0f && horizontalMove > 0) {
            horizontalMove = 0;
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
