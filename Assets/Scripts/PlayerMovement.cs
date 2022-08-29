using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] MovementController movement;

    void Update()
    {
        if (!isLocalPlayer) return;
        Vector2 direction =
            Vector2.ClampMagnitude(
                new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
                1f
                );
            
        movement.direction = direction;
    }
}
