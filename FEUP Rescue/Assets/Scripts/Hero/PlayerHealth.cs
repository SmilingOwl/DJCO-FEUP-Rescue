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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if(!GameLogic.instance.inTimeOut){
            GameLogic.instance.setTimeOut();
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                Die();
            }
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
        animator.SetBool("isDead", true);
        Debug.Log("YOU DIED!");

    }
}
