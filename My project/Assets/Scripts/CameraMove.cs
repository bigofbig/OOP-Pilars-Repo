using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]GameObject ancherPoint;//initialized with Drag&drop

    float rotateSpeed = 10;
    private void Update()
    {
        CameraMovement();
    }

    //Abstraction
void CameraMovement()
    {
        float horizontalInput;
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            float thisMuchFasterThanAutoRotate = 5;//on input rotate is this much faster than auto rotate
            transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * rotateSpeed * thisMuchFasterThanAutoRotate);


        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }


}
