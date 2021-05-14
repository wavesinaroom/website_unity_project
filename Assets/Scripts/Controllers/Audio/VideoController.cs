using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public static VideoController instance;

    private VideoPlayer videoPlayer;

    public bool active;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "wiar.mp4");
    }

    public void SetVideoTime(float time) {
        videoPlayer.time = time;
        videoPlayer.Play();
        active = true;
    }

    public void PlayStop() {
        if (active)
        {
            active = false;
            videoPlayer.Pause();
        }
        else {
            active = true;
            videoPlayer.Play();
        }
    }

}
