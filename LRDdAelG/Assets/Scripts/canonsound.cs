using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonsound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Busca y asigna el componente AudioSource únicamente de este objeto
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // Verifica que el AudioSource no esté ya reproduciendo antes de iniciar el sonido
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}