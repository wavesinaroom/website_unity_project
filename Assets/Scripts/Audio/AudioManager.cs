using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AUDIO_PARAMETERS_LABELS {VOLUME, PITCH};
public enum ASSET_TYPE {MUSIC, SFX, VO}; 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 
    [Header("Music")]
    public AudioSource musicAudioSource; 
    public List<AudioClip> musicClips;
    [Header("SFX")]
    public AudioSource sfxAudioSource;
    public List<AudioClip> sfxClips;
    [Header("VO")]
    public AudioSource voAudioSource; 
    public List<AudioClip> voClips;  
    
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
    public void RandomizeSFXParametre(AUDIO_PARAMETERS_LABELS parametre, float min, float max, AudioSource audioSource)
    {
        float randomizeValue = Random.Range(min, max);
        switch (parametre)
        {
            case AUDIO_PARAMETERS_LABELS.VOLUME:
                Mathf.Clamp(randomizeValue, 0f, 1f);
                audioSource.volume = randomizeValue;
                break;
            case AUDIO_PARAMETERS_LABELS.PITCH:
                Mathf.Clamp(randomizeValue, -3f, 3f);
                audioSource.pitch = randomizeValue;
                break;
        }
    }
    #endregion

    public void RandomizeAudioClip(ASSET_TYPE assetType, int randomMin, int randomMax)
    {
        int randomAsset = Random.Range(randomMin, randomMax); 
        switch(assetType)
        {
            case ASSET_TYPE.MUSIC:
                musicAudioSource.clip = musicClips[randomAsset]; 
                break;
            case ASSET_TYPE.SFX:
                sfxAudioSource.clip = sfxClips[randomAsset];
                break;
            case ASSET_TYPE.VO:
                voAudioSource.clip = voClips[randomAsset]; 
                break; 
        }
    }
}
