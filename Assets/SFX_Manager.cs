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
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayRoll()
    {
        roll.Play();
    }

    public void PlayGoodColor()
    {
        goodColor.Play();
    }

    public void PlayBadColor()
    {
        badColor.Play();
    }

    public void PlayGroundHit()
    {
        groundHit.Play();
    }
}
