using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]BoxCollider obstacleDetectorCollider;
    [SerializeField]Rigidbody capsuleRigidBody;
    [SerializeField]float MoveSpeed;
    private void Awake()
    {
        obstacleDetectorCollider = GetComponent<BoxCollider>();
        capsuleRigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        capsuleRigidBody.AddRelativeForce(Vector3.forward * MoveSpeed);
        
    }
}
