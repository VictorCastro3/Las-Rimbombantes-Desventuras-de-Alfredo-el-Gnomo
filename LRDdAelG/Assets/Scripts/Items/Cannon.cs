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
    private bool restartTimer = false;
    private float timer = 0f;
    public ParticleSystem particlesystem;
    public ParticleSystem playersystem;
    public AudioClip springSound;
    private AudioSource audioSource;
    private void Start()
    {
        particlesystem.Stop();
        playersystem = GameManager.Instance.GetPlayerParticleSystem();
        if (playersystem == null)
        {
            Debug.LogError("No se pudo asignar el sistema de part�culas del jugador.");
        }
    }
    void Update()
    {
        if (isRotating)
        {
            RotateCannon();
        }

        if (isTriggered && Input.GetMouseButtonDown(0))
        {
            LaunchPlayer();
            particlesystem.Play();
        }
        if (restartTimer)
        {
            timer += Time.deltaTime;
            if (timer >= 0.75f)
            {
                timer = 0f;
                restartTimer = false;
                currentRotation = 0f;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playersystem.Stop();
            Debug.Log("PLAYER-11!!!!");
            playerMovement.enabled = false;
            other.transform.Find("GNOMO").gameObject.SetActive(false);
            playerMovement.GetComponent<Rigidbody2D>().gravityScale = 0;
            playerMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
            playersystem.Play();
            playerMovement.enabled = true;
            playerMovement.gameObject.transform.Find("GNOMO").gameObject.SetActive(true);
            playerMovement.GetComponent<Rigidbody2D>().gravityScale = 1;
            playerMovement.Launched(currentRotation, transform.up);
            isTriggered = false;
            isRotating = false;
            restartTimer = true;
            //audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot(springSound);

        }
    }
}
