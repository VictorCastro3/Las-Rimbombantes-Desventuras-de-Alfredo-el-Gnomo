using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class END : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Text sub;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayAudioClip(0);
        SetSubtitleText("Tras finalmente conseguir la tarta definitiva, Alfredo se la come y experimenta un estado de placer gastron�mico que nunca se ha alcanzado y nunca se volver� a alcanzar. Despu�s, vuelve a casa y contin�a con su vida");
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
    public void SetSubtitleText(string newText)
    {
        sub.text = newText;
    }
}
