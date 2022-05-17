using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Move

{
    float flyForce;
    protected override void MoveForward()
    {
        
        capsuleRigidBody.AddRelativeForce(Vector3.up * flyForce);
        capsuleRigidBody.AddRelativeForce(Vector3.forward * moveForce);

    }
    protected override void RotateAround()
    {
        base.RotateAround();
        capsuleRigidBody.AddRelativeForce(Vector3.up * flyForce);
    }
    private void Update()
    {
        FlyForceSetter();
    }
   
    //ABSTRACTION
    void FlyForceSetter()
    {
        if (gameObject.transform.position.y > 6)
        {
            flyForce = 5;
        }
        else
        {
            flyForce = 20;
        }
    }
}
