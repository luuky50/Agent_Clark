using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : SingletonComponent<MusicManager>
{
    [SerializeField]
    AudioMixer audioMixer;
    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Start()
    {
        PlayAudio(audioClips[0]);
    }
    public void PlayAudio(AudioClip audioClip)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void StopAudio()
    {
        //TODO: Stop audio
    }

    IEnumerator StopAudioSmooth() 
    {
        //TODO: Stop audio smoothly
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
