using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public enum RANDOMIZE_AUDIO_CLIPS{TRUE, FALSE};
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 
    [Header("Music")]
    public List<AudioSource> musicAudioSource; 
    [Header("SFX")]
    public List<AudioSource> sfxAudioSource;
    [Header("VO")]
    public List<AudioSource> voAudioSource; 
    [Header("Marimba")]
    public List<AudioSource> marimbaAudioSource; 
    public bool isMusicAudioSourcePaused; 
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Gives randomization control over a specified parametre
     Call method from any GameObject script*/
    /*
    public void RandomizeAssetParametre(ASSET_TYPE assetType, AUDIO_PARAMETERS_LABELS parametre, float paramMin, float paramMax, int randomAssetMin, int randomAssetMax)
    {
        float randomizeValue = Random.Range(paramMin, paramMax);
        Mathf.Clamp(randomizeValue, 0f, 1f);
        Mathf.Clamp(randomizeValue, -3f, 3f);
        
        int randomAsset = Random.Range(randomAssetMin,randomAssetMax); 
        
        if(parametre == AUDIO_PARAMETERS_LABELS.VOLUME)
        {
            storeValueAudioSource.volume = randomizeValue; 
        }else if(parametre == AUDIO_PARAMETERS_LABELS.PITCH)
        {
            storeValueAudioSource.pitch = randomizeValue; 
        }


    }*/
    

}
