using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerProgress : MonoBehaviour {
    private static GameObject playerProgressInstance;

    [SerializeField]
    private int stagesComplete = 0;
    public int getStagesComplet => stagesComplete;
    public void IncrementStagesComplete() => stagesComplete++;

    public List<int> completedLevels = new List<int>();

    public void CompleteLevel(int i) {
        completedLevels.Add(i);
    }

    public bool IsLevelCompleded(int i) {
        if (completedLevels.Contains(i)) {
            return true;
        }

        return false;
    }

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
