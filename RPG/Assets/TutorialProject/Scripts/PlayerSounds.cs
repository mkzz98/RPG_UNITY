using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnMovement(InputValue input)
    {
        if (audioSource != SoundBank.instance.stepAudio)
        {
            audioSource.clip = SoundBank.instance.stepAudio;
            audioSource.loop = true;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
      
      
    }
    private void OnMovementStop(InputValue input)
    {
        audioSource.Pause();
    }
}
