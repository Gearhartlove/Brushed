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
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
