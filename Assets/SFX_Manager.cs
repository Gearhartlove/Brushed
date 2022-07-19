using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private AudioSource dampenedMusic;

    [SerializeField]
    private AudioSource roll;

    [SerializeField]
    private AudioSource goodColor;

    [SerializeField]
    private AudioSource badColor;
    [SerializeField]
    private AudioSource groundHit;
    [SerializeField]
    private AudioSource menuClick;
    [SerializeField]
    private AudioSource sweep;
    [SerializeField]
    private AudioSource victorySound;

    private static GameObject sfxInstance;

    private List<AudioSource> sounds;

    private bool isSoundsMuted;
    public void ToggleSounds() => isSoundsMuted = !isSoundsMuted;
    public bool IsSoundsMuted => isSoundsMuted;
    
    private bool isMusicMuted;
    public void ToggleMusic() => isMusicMuted = !isMusicMuted;
    public bool IsMusicMuted => isMusicMuted;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (sfxInstance == null)
        {
            sfxInstance = gameObject;
        } else
        {
            DestroyObject(gameObject);
        }

        sounds = new List<AudioSource>();

        // Music
        backgroundMusic = GetComponents<AudioSource>()[0];
        dampenedMusic = GetComponents<AudioSource>()[1];

        // Sounds
        roll = GetComponents<AudioSource>()[2];
        badColor = GetComponents<AudioSource>()[3];
        goodColor = GetComponents<AudioSource>()[4];
        groundHit = GetComponents<AudioSource>()[5];
        menuClick = GetComponents<AudioSource>()[6];
        sweep = GetComponents<AudioSource>()[7];
        victorySound = GetComponents<AudioSource>()[8];

        for (int i = 1; i < GetComponents<AudioSource>().Length; i++)
        {
            sounds.Add(GetComponents<AudioSource>()[i]);
        }
    }
    
    public void PlayRoll()
    {
        if (!roll)
        {
            goodColor = GetComponents<AudioSource>()[1];
        }
        roll.Play();
    }

    public void PlayGoodColor()
    {
        if (!goodColor)
        {
            goodColor = GetComponents<AudioSource>()[3];
        }
        goodColor.Play();
    }

    public void PlayBadColor()
    {
        if (!badColor)
        {
            badColor = GetComponents<AudioSource>()[2];
        }
        badColor.Play();
    }

    public void PlayGroundHit()
    {
        if (!groundHit)
        {
            groundHit = GetComponents<AudioSource>()[4];
        }
        groundHit.Play();
    }

    public void PlayMenuClick()
    {
        if (!menuClick)
        {
            menuClick = GetComponents<AudioSource>()[5];
        }
        menuClick.Play();
    }

    public void PlaySweep()
    {
        if (!sweep)
        {
            sweep = GetComponents<AudioSource>()[6];
        }
        sweep.Play();
    }

    public void PlayVictorySound()
    {
        if (!victorySound)
        {
            victorySound = GetComponents<AudioSource>()[7];
        }
        victorySound.Play();
    }

    public void MuteSounds() {
        isSoundsMuted = true;
        foreach(AudioSource sound in sounds)
        {
            sound.mute = true;
        }
    }

    public void UnmuteSounds()
    {
        foreach (AudioSource sound in sounds)
        {
            sound.mute = false;
        }
    }

    public void MuteMusic() {
        isMusicMuted = true;
        backgroundMusic.mute = true;
    }

    public void UnmuteMusic() {
        isMusicMuted = false;
        backgroundMusic.mute = false;
    }

    public void DampMusic()
    {
        // This is not supported in WebGL
        // GetComponent<AudioLowPassFilter>().cutoffFrequency = 550;

        dampenedMusic.volume = 0.8f;
        backgroundMusic.volume = 0;
    }

    public void UndampMusic()
    {
        // This is not supported in WebGL
        // GetComponent<AudioLowPassFilter>().cutoffFrequency = 22000;

        dampenedMusic.volume = 0f;
        backgroundMusic.volume = 0.8f;
    }
}
