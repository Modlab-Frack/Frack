﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
