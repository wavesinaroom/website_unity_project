using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicPortfolioController : MonoBehaviour
{
    [HideInInspector] public static MusicPortfolioController instance; 
    public List<AudioClip> audioClips; 
    AudioSource audioSource; 
     private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void PlayMusicPortfolioClip(int slotNumber)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[slotNumber]; 
        audioSource.Play(); 
    }

}

