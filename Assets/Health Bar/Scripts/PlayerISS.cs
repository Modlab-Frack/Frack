using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerISS : MonoBehaviour {

    [SerializeField]
    private StateISS health;


	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        health.Initialize();
    }

    // Update is called once per frame
    void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentVal += 10;
        }

        if (health.CurrentVal == 0)
        {
            health.CurrentVal = 100;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            
        }
    }

    public void takedamage(float number)
    {
        health.CurrentVal -= number;
    }

  
       
    



}
