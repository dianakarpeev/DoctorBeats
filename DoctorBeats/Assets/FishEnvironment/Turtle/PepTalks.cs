using UnityEngine;

public class pep_talk : MonoBehaviour
{
    public AudioSource myAudio; //Unity component that will play the mp3
    public AudioClip[] audio_clips; //Array to store all mp3 

    void Start()
    {
        InvokeRepeating("Talk", 30f, 30f); //Dr. Beats speaks every 10 seconds
    }
    void Talk()
    {
        if (audio_clips.Length > 0) //Check if there are any voice clips available
        {
            int randomClipIndex = Random.Range(0, audio_clips.Length - 1); //random clip generator
            myAudio.clip = audio_clips[randomClipIndex]; // Assign the randomly chosen clip to the audio source
            myAudio.Play(); //Dr. Beats speaks
        }
    }
}
