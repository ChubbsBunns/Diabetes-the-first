using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogs : MonoBehaviour
{
    public GameObject[] musicToPlay;

    public GameObject currentMusic;

    public int currentAudioLog;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<AudioLogs>().Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
       currentMusic = Instantiate(musicToPlay[0], transform.position, Quaternion.identity);
    }

    public void PlayMusic(int index)
    {
        Destroy(currentMusic);
        currentMusic = Instantiate(musicToPlay[index], transform.position, Quaternion.identity);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}
