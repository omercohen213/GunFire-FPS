using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] CharacterController _characterController;

    [SerializeField] private float _movementSpeed = 7f;

    void Update()
    {
        if (!IsOwner)
            return;        

        float xMove = Input.GetAxis("Horizontal");        
        float zMove = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xMove + transform.forward * zMove;     
        movement.y = 0;

        // Normalize the movement vector to maintain consistent speed diagonally.
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        _characterController.Move(_movementSpeed * Time.deltaTime * movement);
    }
}

