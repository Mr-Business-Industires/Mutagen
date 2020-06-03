using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{

    public Music[] songs;
    int currentSong = 0;


    void Awake()
    {
        foreach (Music s in songs)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixer;
        }

        songs[currentSong].source.Play();

    }

    void FixedUpdate()
    {
        if (!songs[currentSong].source.isPlaying)
        {
            if (currentSong == songs.Length-1)
            {
                currentSong = 0;
            }
            else currentSong += 1;

            songs[currentSong].source.Play();
        }
    }
}
