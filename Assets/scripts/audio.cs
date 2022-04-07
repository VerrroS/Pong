using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class audio : MonoBehaviour
{
    public AudioClip wall;
    public AudioClip score;
    public AudioClip paddle;
    AudioSource audio_source;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void play_audio(string sound)
    {
        if (sound == "wall")
        {
            audio_source.clip = wall;
        }
        if (sound == "score")
        {
            audio_source.clip = score;
        }
        if (sound == "paddle")
        {
            audio_source.clip = paddle;
        }
        audio_source.Play();

    }


}
