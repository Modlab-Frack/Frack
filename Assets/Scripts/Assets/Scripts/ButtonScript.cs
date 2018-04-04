using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[SerializeField]
//private StateISS health;





public class ButtonScript : MonoBehaviour
{


    


    
    private void Start()
    {
        GameObject gameobject = GameObject.FindWithTag("Brian2");
        AudioSource audio = GetComponent<AudioSource>();

        PlayerISS yetAnotherScript;
    }

    
    // public GameObject EventMenuUI;



    public void EndTurn()
	{
        AudioSource audio = GetComponent<AudioSource>();
        

        MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE

        MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 

        GameObject gameobject = GameObject.FindWithTag("Brian2");


        PlayerISS yetAnotherScript;



        yetAnotherScript = gameobject.GetComponent<PlayerISS>();

        yetAnotherScript.takedamage(1);


        //MasterControl.control.eventcard.runEvent();


        //audio.Play();
        Debug.Log("Next Turn");

        //gameobject.takedamage(1);




    }
}
