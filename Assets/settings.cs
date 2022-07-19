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
    private GameObject SoundButton;
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
        SoundOn = true;
        MusicOn = true;
        sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
    }

    public void toggleSound()
    {
        if (SoundOn)
        {
            SoundOn = false;
            SoundButton.GetComponent<Image>().sprite = soundOff;
            sfx.MuteSounds();
        } else
        {
            SoundOn = true;
            SoundButton.GetComponent<Image>().sprite = soundOn;
            sfx.UnmuteSounds();
            sfx.PlayMenuClick();
        }
    }

    public void toggleMusic()
    {
        if (MusicOn)
        {
            MusicOn = false;
            musicButton.GetComponent<Image>().sprite = musicOff;
            sfx.MuteMusic();
            sfx.PlayMenuClick();
        }
        else
        {
            MusicOn = true;
            musicButton.GetComponent<Image>().sprite = musicOn;
            sfx.UnmuteMusic();
            sfx.PlayMenuClick();
        }
    }
}
