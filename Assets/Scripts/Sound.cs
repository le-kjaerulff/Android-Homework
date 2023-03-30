using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] soundFX = new AudioClip[2];

    AudioSource audioPlayer;

    private void OnEnable()
    {
        EventManager.StartRec += PlayRecSound;
        EventManager.StopRec += PlayResultSound;
    }

    private void OnDisable()
    {
        EventManager.StartRec -= PlayRecSound;
        EventManager.StopRec -= PlayResultSound;
    }



    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = this.GetComponent<AudioSource>();
    }

    void PlayRecSound()
    {
        audioPlayer.clip = soundFX[0];
        audioPlayer.loop = true;
        audioPlayer.Play();
    }

    void PlayResultSound()
    {
        audioPlayer.clip = soundFX[1];
        audioPlayer.loop = false;
        audioPlayer.Play();
    }


}
