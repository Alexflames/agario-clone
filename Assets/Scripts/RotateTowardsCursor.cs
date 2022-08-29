using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RotateTowardsCursor : NetworkBehaviour
{
    new Camera camera;
    [SerializeField] RotationController rotationController;
    public float offset = 90f;

    private void Reset()
    {
        rotationController = GetComponentInChildren<RotationController>();
    }

    private void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if (!isLocalPlayer) return;
        var targetLook = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotationController.targetRotation = Quaternion.LookRotation(Vector3.forward, targetLook).eulerAngles.z + offset;
    }
}
