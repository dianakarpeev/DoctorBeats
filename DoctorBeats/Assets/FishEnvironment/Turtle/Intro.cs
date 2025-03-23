using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class intro : MonoBehaviour
{
    public AudioClip CreatureVoice; //Dr. Beats monologue
    public AudioSource intro_source; //Unity component that will play the mp3

    void Start()
    {
       
        intro_source.clip = CreatureVoice; //assigns CreatureVoice audioclip to the clip property of the audio source

        if (CreatureVoice != null) //if we have a valid sound, we play it
            intro_source.Play();
    }
}
