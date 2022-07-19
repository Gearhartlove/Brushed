using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public bool locked;
    
    public void unlock()
    {
        locked = false;
        transform.Find("Locked").gameObject.SetActive(false);
    }
}
