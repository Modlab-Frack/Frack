using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEvent : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject EventMenuUI;

  
    public void runEvent()
    {
        
        //EventMenuUI= GameObject.FindWithTag("Brian");


        Debug.Log("running event");

        EventMenuUI.SetActive (true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
