using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> audios;
    private AudioSource _audioSource;
    
    
    void Start()
    { _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_audioSource.isPlaying) NewTrack();
    }

    void NewTrack()
    {
        AudioClip audio = audios[Random.Range(0, audios.Count)];
        _audioSource.clip = audio;
        _audioSource.Play();
    }
}
