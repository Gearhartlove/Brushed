using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour
{

    [SerializeField]
    private PlayerProgress playerProgress;

    private GameObject[] stages;

    [SerializeField]
    private GameObject levels;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i <= playerProgress.getStagesComplet; i++)
        {
            levels.transform.GetChild(i).GetComponent<Level_Manager>().unlock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadStage(int newStage)
    {
        if (!levels.transform.GetChild(newStage - 1).GetComponent<Level_Manager>().locked)
        {
            Debug.Log("unlocked");
            GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayGroundHit();
            SceneManager.LoadScene(newStage);
        } else
        {
            // Could play different sound if stage is locked
            Debug.Log("is locked");
        }
        
    }
}
