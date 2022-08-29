using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float targetRotation;
    public float rotationSpeed = 60f; 

    void Start()
    {
        targetRotation = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float currentRotationZ = currentRotation.z;
        float newRotation =
            Mathf.MoveTowardsAngle(currentRotationZ, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, newRotation);
    }
}
