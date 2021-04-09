using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Alarm : MonoBehaviour
{

    [SerializeField]
    VolumeProfile alarm;

    [SerializeField]
    float alarmSpeed;

    bool isRed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startAlarm());
        MusicManager.instance.PlayAudio(MusicManager.instance.audioClips[1]);
    }

    private IEnumerator startAlarm()
    {
        while (true)
        {
            isRed = !isRed;
            if (alarm.TryGet<ColorAdjustments>(out var colorAdjust))
            {
                colorAdjust.colorFilter.overrideState = true;
                if (isRed)
                    colorAdjust.colorFilter.value = Color.red;
                else
                    colorAdjust.colorFilter.value = Color.white;
            }
            yield return new WaitForSeconds(alarmSpeed);
        }
    }
}
