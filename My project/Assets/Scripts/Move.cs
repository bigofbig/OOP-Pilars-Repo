using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    BoxCollider obstacleDetectorCollider;
   [SerializeField]protected Rigidbody capsuleRigidBody;
   [SerializeField]protected float moveForce=7;//how much force is added to move the gameobject
   [SerializeField]protected float maxVelocity = 3;
    [SerializeField] float rotateSpeed= 0.05f;
    float rotateDelay=1;
    float stuckCountDown = 5;
    int rotateDirection = 1;
    protected bool isBlocked = false;//is the character way blocked by an obstacle?
    bool isRotateDirectionSet = false;
   
   
    
 


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
            StopMoving();
            
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
            stuckCountDown = 5;
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

   protected virtual void MoveForward()
    {
        capsuleRigidBody.AddRelativeForce(Vector3.forward * moveForce);
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
        if (capsuleRigidBody.velocity.magnitude > maxVelocity)
        {
            capsuleRigidBody.velocity = Vector3.ClampMagnitude(capsuleRigidBody.velocity, maxVelocity);
        }
    }
    void StopMoving()
    {
        float stopDelay = 2;
        capsuleRigidBody.velocity = Vector3.ClampMagnitude(capsuleRigidBody.velocity, stopDelay);
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
