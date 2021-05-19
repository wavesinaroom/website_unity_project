using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public static VideoController instance;

    [Header("Path")]
    public string path;

    [HideInInspector] public VideoPlayer videoPlayer;

    public bool active;
    public bool volume;

    private void OnEnable()
    {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, path);
    }

    public void SetVideoTime(float time) {
        videoPlayer.time = time;
        videoPlayer.Play();
        active = true;
        volume = true;
    }

    public void SetVolume() {
        if (volume)
        {
            volume = false;
            videoPlayer.audioOutputMode = VideoAudioOutputMode.None;
        }
        else {
            volume = true;
            videoPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
        }
    }

    public void Play() {
        if (!active)
        {
            active = true;
            videoPlayer.Play();
        }
    }

    public void Stop() {
        if (active)
        {
            active = false;
            videoPlayer.Pause();
        }
    }

}
