using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 0f);
        animator.gameObject.transform.position += new Vector3(Thief.instance.transform.position.x - animator.gameObject.transform.position.x, 
            Thief.instance.transform.position.y + animator.gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2.0f -
            animator.gameObject.transform.position.y, 0f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.position -= new Vector3(Time.deltaTime * ObstacleController.instance.obstacleVelocity, 0f, 0f);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SetActive(false);
        Thief.instance.TakeDamage(100);
    }
}
