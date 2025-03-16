using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Aseg�rate de que el Audio Source est� asignado en el Inspector
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        audioSource.Play();
    }
}
