using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip footstepSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayFootstepSound()
    {
        AudioClip clip = footstepSound;
        audioSource.clip = clip;
        audioSource.volume = Random.Range(0.05f, 0.08f);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
}
