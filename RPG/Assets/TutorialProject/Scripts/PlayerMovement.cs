using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Vector3 movementInput;
    Vector3 movementVector;

    [SerializeField] float movementSpeed, jumpPower;

    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }

    private void OnMovement(InputValue input)
    { 
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }
    private void OnJump(InputValue input)
    {
        characterRB.velocity = new Vector3(0, jumpPower, 0) * (float)Time.fixedDeltaTime;
    }

    private void ApplyMovement()
    {
        if (movementInput != Vector3.zero)
        {
            movementVector = movementInput.x * transform.right + movementInput.z * transform.forward;
            movementVector.y = 0;
            characterRB.velocity = movementVector * (float)Time.fixedDeltaTime * movementSpeed;
        }
 
        
    }
    private void OnCrouch(InputValue input)
    {
        movementSpeed /= 2;
    }
    private void OnCrouchStop(InputValue input)
    {
        movementSpeed = 150;
    }

    private void OnSprint(InputValue input)
    {
        movementSpeed *= 2;
    }
    private void OnSprintStop(InputValue input)
    {
        movementSpeed = 150;
    }
   
    private void OnMovementStop()
    {
         movementVector = Vector3.zero;
    }
}