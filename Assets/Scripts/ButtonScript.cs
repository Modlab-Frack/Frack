using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]



public class ButtonScript : MonoBehaviour
{
    /*
    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
    */

   // public GameObject EventMenuUI;



    public void EndTurn()
	{
        AudioSource audio = GetComponent<AudioSource>();
        MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE

        MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 


        MasterControl.control.eventcard.runEvent();

        //MasterControl.control.eventcard.runEvent();


        audio.Play();
        Debug.Log("Next Turn");




    }
}
