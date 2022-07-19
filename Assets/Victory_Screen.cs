using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Victory_Screen : MonoBehaviour
{
    [SerializeField]
    private GameObject Dice;

    [SerializeField]
    private GameObject RegularUI;

    private SFX_Manager sfx;

    private GameObject cam;

    private GameObject vCam;

    private bool movingToTop;

    private Vector3 endPosition;
    private Quaternion endRotation;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
    }

    private void Awake()
    {
        movingToTop = false;
        endPosition = new Vector3(0, 25, 0);
        endRotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToTop)
        {
            Vector3 newPosition = Vector3.Lerp(cam.transform.position, endPosition, Time.deltaTime);
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, endRotation, Time.deltaTime);

            
            cam.transform.position = newPosition;
            cam.transform.rotation = newRotation;
            // vCam.GetComponent<CinemachineFreeLook>().ForceCameraPosition(newPosition, Quaternion.Euler(0, 90, 0));
            if (cam.transform.position == endPosition) {
                movingToTop = false;
            }
        }
    }

    public void Win()
    {
        RegularUI.SetActive(false);
        Dice.GetComponent<Controls>().isComplete = true;

        /*
        vCam = GameObject.Find("VCam");
        cam = GameObject.Find("Main Camera");
        vCam.SetActive(false);
        movingToTop = true;
        */

        if (!sfx)
        {
            sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
        }
        sfx.PlayVictorySound();
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
