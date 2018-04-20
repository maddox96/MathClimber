using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager> {

    AudioSource audioSource;
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("Music manager doesn't have audio source. ");
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if(clip != null)
            audioSource.PlayOneShot(clip);
    }
}
