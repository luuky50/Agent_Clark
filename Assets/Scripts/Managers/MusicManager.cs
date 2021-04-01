using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioMixerGroup audioMixerGroup;
    [SerializeField]
    List<AudioClip> audioClips = new List<AudioClip>();

    // Start is called before the first frame update
    void PlayAudio()
    {
        
    }


    public void PlayNextAudio()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
