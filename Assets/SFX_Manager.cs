using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic;

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

    private static GameObject sfxInstance;

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

        backgroundMusic = GetComponents<AudioSource>()[0];
        roll = GetComponents<AudioSource>()[1];
        badColor = GetComponents<AudioSource>()[2];
        goodColor = GetComponents<AudioSource>()[3];
        groundHit = GetComponents<AudioSource>()[4];
        menuClick = GetComponents<AudioSource>()[5];
        sweep = GetComponents<AudioSource>()[6];
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void MuteSounds()
    {
        roll.mute = true;
        badColor.mute = true;
        goodColor.mute = true;
        groundHit.mute = true;
        menuClick.mute = true;
        sweep.mute = true;
    }

    public void UnmuteSounds()
    {
        roll.mute = false;
        badColor.mute = false;
        goodColor.mute = false;
        groundHit.mute = false;
        menuClick.mute = false;
        sweep.mute = false;
    }

    public void MuteMusic()
    {
        backgroundMusic.mute = true;
    }

    public void UnmuteMusic()
    {
        backgroundMusic.mute = false;
    }
}
