using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEvent : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject EventMenuUI;

  
    void Start()
    {

    }

    public void runEvent()
    {
        
        //EventMenuUI= GameObject.FindWithTag("Brian");


        Debug.Log("running event");

        GameObject paddleGameObject = GameObject.Find("EventMenu");
        paddleGameObject.SetActive(true);
        EventMenuUI.SetActive (true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
