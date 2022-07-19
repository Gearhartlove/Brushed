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

    private SFX_Manager sfx;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
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
        if (!sfx)
        {
            sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
        }
        sfx.DampMusic();
    }

    public void Resume()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        isPaused = false;
        Dice.GetComponent<Controls>().isPaused = false;
        RegularUI.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        gameObject.SetActive(false);
        sfx.UndampMusic();
    }

    public void Restart()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        sfx.UndampMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlayMenuClick();
        sfx.UndampMusic();
        SceneManager.LoadScene("Level Select");
    }
}
