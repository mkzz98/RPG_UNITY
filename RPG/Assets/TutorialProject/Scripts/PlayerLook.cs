using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int mouseSensitivity;
    [SerializeField] Transform playerCamera;
    float xRotation, yRotation;
    float mouseX,mouseY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX *= (float)Time.deltaTime * mouseSensitivity; 
        mouseY *= (float)Time.deltaTime * mouseSensitivity;
        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation,-35,40);
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
    private void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }
}
