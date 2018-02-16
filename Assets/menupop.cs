using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menupop : MonoBehaviour {

    public GameObject menuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            Runevent();
        }
	}

    public void Runevent()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void prdecline()
    {
        Debug.Log("PR Level has decreased");
        /* stat changes */
    }

    public void praccept()
    {
        Debug.Log("PR Level has increase");
        /*Stat changes*/
    }
}

//need to
//get reference to menugameobject
//get reference to stat changes
//not allow any other option; could be done by loading a new scene?
