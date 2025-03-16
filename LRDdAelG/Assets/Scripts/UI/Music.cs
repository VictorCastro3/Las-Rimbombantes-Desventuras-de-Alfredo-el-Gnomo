using System.Collections;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayAudioClip();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayAudioClip()
    {

        audioSource.clip = audioClip;
        audioSource.Play();
        StartCoroutine(ReplayAudioClip(audioClip.length));

    }
    private IEnumerator ReplayAudioClip(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        audioSource.Play();
        StartCoroutine(ReplayAudioClip(clipLength));
    }
}
