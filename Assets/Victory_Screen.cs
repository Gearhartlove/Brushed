using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory_Screen : MonoBehaviour
{
    [SerializeField]
    private GameObject Dice;

    [SerializeField]
    private GameObject RegularUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Win()
    {
        RegularUI.SetActive(false);
        Dice.GetComponent<Controls>().isComplete = true;
    }

    public void LevelSelect()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        SceneManager.LoadScene("Level Select");
    }

    public void NextLevel()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        var newStage = SceneManager.GetActiveScene().buildIndex;
        newStage += 1; // go to the next stage
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
        Debug.Log("New Stage Index: " + newStage + " , Loading: " + load);
        SceneManager.LoadScene(load);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
