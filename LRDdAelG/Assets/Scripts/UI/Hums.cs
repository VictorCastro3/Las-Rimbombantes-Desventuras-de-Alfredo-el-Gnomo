using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hums : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource audioSource;

    [SerializeField]
    private float humTime = 15f;

    private System.Random rnd = new System.Random();
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= humTime)
        {
            int hum = rnd.Next(1, 13);
            if (hum == 1) PlayAudioClip(1);
            else if (hum == 2) PlayAudioClip(2);
            else if (hum == 3) PlayAudioClip(3);
            else if (hum == 4) PlayAudioClip(4);
            else if (hum == 5) PlayAudioClip(5);
            else if (hum == 6) PlayAudioClip(6);
            else if (hum == 7) PlayAudioClip(7);
            else if (hum == 8) PlayAudioClip(8);
            else if (hum == 9) PlayAudioClip(9);
            else if (hum == 10) PlayAudioClip(10);
            else if (hum == 11) PlayAudioClip(11);
            else if (hum == 12) PlayAudioClip(12);
            time = 0f;
        }
    }

    private void PlayAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }
}
