using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIndex : MonoBehaviour
{
    // Start is called before the first frame update
    public int audioIndex;
    private void Awake()
    {
        AudioLogs audioLog = FindObjectOfType<AudioLogs>();
        if (audioLog.currentAudioLog == audioIndex)
        {
            Debug.Log("Yay");
        }
        else
        {
            audioLog.currentAudioLog = audioIndex;
            audioLog.PlayMusic(audioIndex);
        }
    }
}
