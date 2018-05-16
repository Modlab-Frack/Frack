using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	public void EndTurn()
	{
        //Brian Code
        AudioSource audio = GetComponent<AudioSource>();
        //MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE
        //MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 
        GameObject gameobject = GameObject.FindWithTag("Brian2");
        PlayerISS yetAnotherScript;
        yetAnotherScript = gameobject.GetComponent<PlayerISS>();
        yetAnotherScript.takedamage(1);

        //Joe
        MasterControl.control.currGame.EndTurn();
	}
}
