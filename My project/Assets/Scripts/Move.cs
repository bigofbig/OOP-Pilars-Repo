using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]BoxCollider obstacleDetectorCollider;
    [SerializeField]Rigidbody capsuleRigidBody;
    [SerializeField]float moveSpeed;
    [SerializeField]float rotateSpeed;
    [SerializeField]float rotateDelay;
    [SerializeField]bool isBlocked = false;
    
    private void Awake()
    {
      

        obstacleDetectorCollider = GetComponent<BoxCollider>();
        capsuleRigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!isBlocked)
        {
            capsuleRigidBody.AddRelativeForce(Vector3.forward * moveSpeed);
        }
        if (isBlocked) {
            capsuleRigidBody.constraints = 
            RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezeRotationX;
            capsuleRigidBody.AddRelativeTorque(Vector3.up*rotateSpeed);
            print("torqueing");
        }
        if (!isBlocked) { capsuleRigidBody.constraints =
                RigidbodyConstraints.FreezeRotationY|
                RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezeRotationX; 
            print("Y rotation constrained");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {

            isBlocked = true;
            
        }


    }
    private void OnTriggerExit(Collider other)
    {

        Invoke("IsBlockedSetter", rotateDelay);//delayed, to prevent stucking
        

        

    }

   void IsBlockedSetter()
    {
        isBlocked = false;
    }
}
