using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    [SerializeField]
    private bool SoundOn;
    [SerializeField]
    private bool MusicOn;

    [SerializeField]
    private GameObject soundButton;
    [SerializeField]
    private GameObject musicButton;

    [SerializeField]
    private Sprite soundOn;
    [SerializeField]
    private Sprite soundOff;

    [SerializeField]
    private Sprite musicOn;
    [SerializeField]
    private Sprite musicOff;

    private SFX_Manager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
        
        // Check sfx to see if sounds are muted when loading the scene. 
        // Update UI based on results.
        
        // Sound
        if (sfx.IsSoundsMuted) {
            soundButton.GetComponentInChildren<Image>().sprite = soundOff;
            SoundOn = false;
        }
        else {
            soundButton.GetComponentInChildren<Image>().sprite = soundOn;
            SoundOn = true;
        }

        // Music
        if (sfx.IsMusicMuted) {
            musicButton.GetComponentInChildren<Image>().sprite = musicOff;
            MusicOn = false;
        }
        else {
            musicButton.GetComponentInChildren<Image>().sprite = musicOn;
            MusicOn = true;
        }
    }

    public void toggleSound()
    {
        if (SoundOn) {
            SoundOn = false;
            soundButton.GetComponentInChildren<Image>().sprite = soundOff;
            sfx.MuteSounds();
        } 
        else {
            SoundOn = true;
            soundButton.GetComponentInChildren<Image>().sprite = soundOn;
            sfx.UnmuteSounds();
            sfx.PlayMenuClick();
        }
    }

    public void toggleMusic()
    {
        if (MusicOn)
        {
            MusicOn = false;
            musicButton.GetComponentInChildren<Image>().sprite = musicOff;
            sfx.MuteMusic();
            sfx.PlayMenuClick();
        }
        else
        {
            MusicOn = true;
            musicButton.GetComponentInChildren<Image>().sprite = musicOn;
            sfx.UnmuteMusic();
            sfx.PlayMenuClick();
        }
    }
}
