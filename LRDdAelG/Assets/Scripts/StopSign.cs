using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private bool stopped = false;
    private Collider2D stopCollider;
    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        stopCollider = GetComponent<Collider2D>();  // Obtener el Collider2D de la señal de stop
        stopCollider.enabled = true;  // Asegurarse de que el collider esté habilitado
    }

    // Update is called once per frame
    void Update()
    {    
        if (stopped && Input.GetMouseButtonDown(0)) 
        {
            ReanudeMove();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("WAIT, then Click");
            playerMovement.enabled = false;  // Detiene el movimiento del jugador
            stopped = true;  // Marca que el jugador está detenido
            stopCollider.enabled = true;
        }

    }

    private void ReanudeMove()
    {
        if (stopped) 
        {
            playerMovement.enabled = true;
            stopped = false;
            stopCollider.enabled = false;
        }
    }

}
