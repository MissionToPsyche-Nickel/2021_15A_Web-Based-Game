using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script only exists to destroy a game object at the end of an animation. We can use it for
//  the asteroid and power-up animations
public class DestroyObject : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length/2);
    }
}
