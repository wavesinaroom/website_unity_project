using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioClipRandomizer : MonoBehaviour
{

    public List<AudioClip> audioClips; 
    private AudioSource audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count - 1)]; 
        
    }


}
