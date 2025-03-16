using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Asegúrate de que el Audio Source esté asignado en el Inspector
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        audioSource.Play();
    }
}
