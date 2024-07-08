using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audio_clips;

    AudioSource bgm_player;
    AudioSource sfx_player;

    void Awake()
    {
        bgm_player = GameObject.Find("BGM Player").GetComponent<AudioSource>();
        sfx_player = GameObject.Find("SFX Player").GetComponent<AudioSource>();
    }

    public void PlaySound(string type)
    {
        int index = 0;

        switch (type)
        {
            case "Touch": index = 0; break;
        }

        sfx_player.clip = audio_clips[index];
        sfx_player.Play();
    }
}
