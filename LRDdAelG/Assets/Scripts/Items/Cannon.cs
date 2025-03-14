using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private bool isTriggered = false;
    private PlayerMovement playerMovement;
    private bool isRotating = false;
    private float rotationAngle = 45f;
    [SerializeField]private float rotationSpeed = 5f;
    private float currentRotation = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        if (isRotating)
        {
            RotateCannon();
        }

        if (isTriggered && Input.GetMouseButtonDown(0))
        {
            LaunchPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            Debug.Log("PLAYER-11!!!!");
            playerMovement.enabled = false;
            isTriggered = true;
            isRotating = true;
        }
    }

    private void RotateCannon()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (rotatingRight)
        {
            currentRotation += rotationStep;
            if (currentRotation >= rotationAngle)
            {
            rotatingRight = false;
            }
        }
        else
        {
            currentRotation -= rotationStep;
            if (currentRotation <= -rotationAngle)
            {
            rotatingRight = true;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    private void LaunchPlayer()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
            playerMovement.Launched(currentRotation);
            isTriggered = false;
            isRotating = false;
            currentRotation = 0f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
