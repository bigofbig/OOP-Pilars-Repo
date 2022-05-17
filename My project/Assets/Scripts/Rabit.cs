using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabit : Move //INHERITANCE
{
   [SerializeField]float jumpForce =200;
   [SerializeField] float jumpDelay = 1;
   float jumpTimer = 0;
    [SerializeField] Animator animator;
    
    

    //POLYMORPHISM
    protected override void MoveForward()
    {
        animator.SetBool("isJumping", false);
        maxVelocity = 10;
        moveForce = 40;
        jumpTimer -= Time.deltaTime;
        if (jumpTimer < 0)
        {
            animator.SetBool("isJumping", true);
            capsuleRigidBody.AddRelativeForce(Vector3.up * jumpForce);
            capsuleRigidBody.AddRelativeForce(Vector3.forward * moveForce);
            jumpTimer = jumpDelay;
           
            
        }
       
        
       
        

    }
 

}
