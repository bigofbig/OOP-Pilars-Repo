using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] BoxCollider obstacleDetectorCollider;
    [SerializeField] Rigidbody capsuleRigidBody;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rotateDelay;
    [SerializeField] bool isBlocked = false;//is the character way blocked by an obstacle?
    [SerializeField] bool isRotateDirectionSet = false;
    [SerializeField] int rotateDirection = 1;
    [SerializeField] float maxMoveSpeed;
    float stuckCountDown=10;
 


    private void Awake()
    {
        

        obstacleDetectorCollider = GetComponent<BoxCollider>();
        capsuleRigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        


       MoveSpeedLimiter(); 

        //ABSTRACTION
        MovementMethod();
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
        Invoke("IsRotateDirectionSetter",rotateDelay);//delayed, to prevent stucking



    }

    private void OnTriggerStay(Collider other)
    {
       
         
            stuckCountDown -= Time.deltaTime;
            print(stuckCountDown);
        if (stuckCountDown < 0)
        {
            isBlocked = true;
            stuckCountDown = 10;
        }
        

    }
    void MovementMethod()
    {

        if (!isBlocked)
        {
            ConstraintsAllAngels();
            MoveForward();
        }
        if (isBlocked)
        {

            RotateAround();
        }
        
    }

    void MoveForward()
    {
        capsuleRigidBody.AddRelativeForce(Vector3.forward * moveSpeed);
    }//How character Goes forward
    void RotateAround()
    {  
        if (!isRotateDirectionSet) { 
         rotateDirection = RandomDirection();
            isRotateDirectionSet = true;
        }
        print(rotateDirection);
        
        capsuleRigidBody.constraints =
            RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezeRotationX;
        capsuleRigidBody.AddRelativeTorque(Vector3.up * rotateSpeed * rotateDirection);
        print("torqueing");
    }

    void MoveSpeedLimiter()
    {
        if (capsuleRigidBody.velocity.magnitude > maxMoveSpeed)
        {
            capsuleRigidBody.velocity = Vector3.ClampMagnitude(capsuleRigidBody.velocity,maxMoveSpeed);
        }
    }



    void IsBlockedSetter()
    {
        isBlocked = false;
    }
    void IsRotateDirectionSetter()
    {
        isRotateDirectionSet = false;
    }
    void ConstraintsAllAngels()
    {
        capsuleRigidBody.constraints =
RigidbodyConstraints.FreezeRotationY |
RigidbodyConstraints.FreezeRotationZ |
RigidbodyConstraints.FreezeRotationX;
        
    }
    int RandomDirection()
    {
        int[] randomDirection = new int[2];
        randomDirection[0] = 1;
        randomDirection[1] = -1;
        ///
        int zeroOrOne = Random.Range(0, 2);
        ///
        return randomDirection[zeroOrOne];


    }//return 1 or -1

}
