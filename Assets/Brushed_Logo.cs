using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brushed_Logo : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("playSound", 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        GameObject.Find("SFX").GetComponent<SFX_Manager>().PlaySweep();
    }
}
