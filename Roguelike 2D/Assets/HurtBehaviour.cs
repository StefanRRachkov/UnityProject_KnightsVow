using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBehaviour : StateMachineBehaviour
{
    private Health health;
    private Animator anim;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim = animator;
        health = animator.GetComponent<Health>();
        health.OnDamageTaken += ChangeHealth;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        health.OnDamageTaken -= ChangeHealth;
    }
    
    void ChangeHealth(int currentHealth)
    {
        anim.SetInteger("Health", currentHealth);
    }
}
