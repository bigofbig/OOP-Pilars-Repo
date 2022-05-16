using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceTest : Move
{
    [SerializeField]float jumpForce;
    [SerializeField]float jumpTimer = 0;
    [SerializeField]float jumpDelay = 3;
    
    protected override void MoveForward()
    {
        maxVelocity = 10;
        jumpTimer -= Time.deltaTime;
        if (jumpTimer < 0)
        {

            capsuleRigidBody.AddRelativeForce(Vector3.up * jumpForce);
            capsuleRigidBody.AddRelativeForce(Vector3.forward * moveForce);
            jumpTimer = jumpDelay;
        }
        

    }

}
