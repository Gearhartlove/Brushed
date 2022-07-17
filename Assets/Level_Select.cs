using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadStage(int newStage)
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayGroundHit();
        SceneManager.LoadScene(newStage);
    }
}
