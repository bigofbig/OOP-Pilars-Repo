using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]GameObject ancherPoint;//initialized with Drag&drop
    float horizontalInput;
    [SerializeField]float rotateSpeed;
    private void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up*Time.deltaTime*horizontalInput*rotateSpeed);
    }

}
