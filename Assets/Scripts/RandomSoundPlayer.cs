using UnityEngine;
using System.Collections;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip soundClip;  // Przypisz dźwięk w Inspectorze
    public float minDelay = 5f;  // Minimalny czas między dźwiękami
    public float maxDelay = 15f; // Maksymalny czas między dźwiękami

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        StartCoroutine(PlayRandomSound());
    }

    IEnumerator PlayRandomSound()
    {
        while (true)
        {
            float randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);
            audioSource.Play();
        }
    }
}

