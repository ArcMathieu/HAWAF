using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;

    public void StartVideo(UnityEngine.Video.VideoClip myVideo) {
        videoPlayer.clip = myVideo;
        videoPlayer.Play();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }
}
