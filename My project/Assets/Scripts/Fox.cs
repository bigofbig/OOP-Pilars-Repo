using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Move
{
    [SerializeField] Animator animator;//Drag&droped

    private void Update()
    {
        Animation();


    }
    //ABSTRACTION
    void Animation()
    {
        if (capsuleRigidBody.velocity.magnitude > 2)
        {
            animator.SetBool("isRunning", true);
        }
        if (capsuleRigidBody.velocity.magnitude < 2)
        {
            animator.SetBool("isRunning", false);
        }
    }
    



}
