using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Thief thief;

    public float speed = 2f;
    public float attackRange = 4f;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        thief = animator.GetComponent<Thief>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(!thief.dead && Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
