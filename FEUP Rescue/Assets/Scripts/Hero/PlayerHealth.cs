using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public int appleValue = 10;
    public Animator animator;
    public HealthBar healthBar;
    bool dead = false;
    public Behaviour halo;
    public static PlayerHealth instance;

    void Awake() {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        dead = false;
    }

    public void TakeDamage(int damage)
    {
        if(!GameLogic.instance.isProtected()){
            if(!GameLogic.instance.inTimeOut && !dead){
                GameLogic.instance.setTimeOut();
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
                animator.SetTrigger("Hurt");
                FindObjectOfType<AudioManager>().Play("heroHurt");

                if (currentHealth <= 0)
                {
                    dead = true;
                    Die();
                }
            }
        }
    }

    public void SetProtected(bool protectedShield) {
        if(protectedShield) {
            halo.enabled = true;
        } else {
            halo.enabled = false;
        }
    }
    public void GetLife() {
        currentHealth += appleValue;
        if(currentHealth >= 100)
            currentHealth = 100;
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        if(GameLogic.instance.HasGameEnded())
            return;
        animator.SetBool("isDead", true);
        GameLogic.instance.GameOver("You lost your life!");
    }
}
