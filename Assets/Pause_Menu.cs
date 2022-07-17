using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject Dice;

    [SerializeField]
    private GameObject RegularUI;

    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        RegularUI.SetActive(false);
        isPaused = true;
        Dice.GetComponent<Controls>().isPaused = true;
    }

    public void Resume()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        isPaused = false;
        Dice.GetComponent<Controls>().isPaused = false;
        RegularUI.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        SceneManager.LoadScene(0);
    }
}
