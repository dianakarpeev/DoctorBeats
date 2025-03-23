using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSounds : MonoBehaviour
{
    private AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] audioGameObjects = GameObject.FindGameObjectsWithTag("FishAudio");
        if(audioGameObjects.Length < 1)
        {
            Debug.Log("Issue");
        }
        audioSources = new AudioSource[audioGameObjects.Length];
        for(int i = 0; i < audioGameObjects.Length; i++)
        {
            audioSources[i]=audioGameObjects[i].GetComponent<AudioSource>();    
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopAllSounds()
    {
        foreach(AudioSource a in audioSources)
        {
            a.Stop();
        }
    }
}
