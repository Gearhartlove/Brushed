using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour
{
    private PlayerProgress playerProgress;

    private GameObject[] stages;

    [SerializeField]
    private GameObject levels;

    [SerializeField]
    private GameObject settings;

    private int levelReveal;

    // Start is called before the first frame update
    void Start() {
        playerProgress = GameObject.Find("PlayerProgress").GetComponent<PlayerProgress>();
        levelReveal = 0;
        Debug.Log(playerProgress.getStagesComplet);
        for (int i = 0; i <= playerProgress.getStagesComplet; i++)
        {
            levels.transform.GetChild(i).GetComponent<Level_Manager>().unlock();
        }

        InvokeRepeating("RevealLevels", 0.8f, 0.4f);
        Invoke("RevealSettings", 0.6f);
    }

    public void LoadStage(int newStage)
    {
        if (!levels.transform.GetChild(newStage - 1).GetComponent<Level_Manager>().locked)
        {
            Debug.Log("unlocked");
            GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
            string load = "";
            switch (newStage) {
                case 1:
                    load = "StageOneTarget";
                    break;
                case 2:
                    load = "StageFiveWindow";
                    break;
                case 3:
                    load = "StageSixBee";
                    break;
                case 4:
                    load = "StageTwoGrasslands";
                    break;
                case 5:
                    load = "StageSevenSwim";
                    break;
                case 6:
                    load = "StageFourSmiley";
                    break;
                case 7:
                    load = "StageThreeAbstract";
                    break;
                case 8:
                    load = "StageEightCake";
                    break;
            }
            SceneManager.LoadScene(load);
        } else
        {
            // Could play different sound if stage is locked
            Debug.Log("is locked");
        }
        
    }

    public void RevealSettings()
    {
        settings.SetActive(true);
    }

    public void RevealLevels()
    {
        if (levelReveal >7)
        {
            CancelInvoke();
        }
        else {
            Debug.Log("level reveal: " + levelReveal);
            levels.transform.GetChild(levelReveal).gameObject.SetActive(true);
            GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayGroundHit();
            levelReveal++;
        }
        
    }
}
