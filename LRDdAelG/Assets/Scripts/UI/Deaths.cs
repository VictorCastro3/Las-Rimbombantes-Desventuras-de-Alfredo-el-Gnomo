using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deaths : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private System.Random rnd = new System.Random();
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }
    public void DeathSound()
    {
        int deathSound = rnd.Next(1, 5);
        if (deathSound == 1) PlayAudioClip(0);
        else if (deathSound == 2) PlayAudioClip(1);
        else if (deathSound == 3) PlayAudioClip(2);
        else if (deathSound == 4) PlayAudioClip(3);
    }
}
