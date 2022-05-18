using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]GameObject ancherPoint;//initialized with Drag&drop

    private void Update()
    {
        transform.Rotate(Vector3.up*Time.deltaTime);
    }

}
