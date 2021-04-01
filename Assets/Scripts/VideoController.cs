using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    GameObject currentVideoPlayer;
    public void PlayClip(GameObject currentVideo)
    {
        if (currentVideoPlayer != null)
        {
            currentVideoPlayer.GetComponent<VideoPlayer>().Stop();
        }
        else
        {
            currentVideoPlayer = currentVideo;
            currentVideo.GetComponent<VideoPlayer>().Play();
        }

    }

}
