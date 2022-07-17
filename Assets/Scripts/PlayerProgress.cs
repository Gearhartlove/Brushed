using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerProgress : MonoBehaviour {
    private GameObject playerProgressInstance;

    [SerializeField]
    private int stagesComplete = 0;
    public int getStagesComplet => stagesComplete;
    public void IncrementStagesComplete() => stagesComplete++;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (playerProgressInstance == null)
        {
            playerProgressInstance = gameObject;
        } else
        {
            DestroyObject(gameObject);
        }
    }
}
