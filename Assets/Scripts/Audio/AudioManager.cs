using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AUDIO_PARAMETERS_LABELS {VOLUME, PITCH};
public enum ASSET_TYPE {MUSIC, SFX, UISFX, VO}; 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 
    [Header("Music")]
    public AudioSource musicAudioSource; 
    public List<AudioClip> musicClips;
    [Header("SFX")]
    public AudioSource sfxAudioSource;
    public List<AudioClip> sfxClips;
    [Header("UISFX")]
    public AudioSource uiSfxAudioSource;
    public List<AudioClip> uiSfxClips; 
    [Header("VO")]
    public AudioSource voAudioSource; 
    public List<AudioClip> voClips;  
    AudioSource storeValueAudioSource;  
          
    
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

    #region Radomize SFX
    /*Gives randomization control over a specified parametre
     Call method from any GameObject script*/
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


        switch(assetType)
        {
            case ASSET_TYPE.MUSIC:
                musicAudioSource.clip = musicClips[randomAsset]; 
                musicAudioSource.volume = storeValueAudioSource.volume;
                musicAudioSource.pitch = storeValueAudioSource.pitch; 
                break; 
            case ASSET_TYPE.SFX:
                sfxAudioSource.clip = sfxClips[randomAsset];
                sfxAudioSource.volume = storeValueAudioSource.volume;
                sfxAudioSource.pitch = storeValueAudioSource.pitch;
                break;
            case ASSET_TYPE.UISFX:
                uiSfxAudioSource.clip = uiSfxClips[randomAsset]; 
                uiSfxAudioSource.volume = storeValueAudioSource.volume;
                uiSfxAudioSource.pitch = storeValueAudioSource.pitch;
                break;
            case ASSET_TYPE.VO:
                voAudioSource.clip = voClips[randomAsset]; 
                voAudioSource.volume = storeValueAudioSource.volume;
                voAudioSource.pitch = storeValueAudioSource.pitch;
                break; 
        }
        
        
    }
    #endregion

}
