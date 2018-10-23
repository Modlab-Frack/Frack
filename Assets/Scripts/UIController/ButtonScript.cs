using UnityEngine;
using System.Collections;


public class ButtonScript : MonoBehaviour
{

    public int decrementa = 10;
    public int decrementb = 10;
    public int decrementc = 10;

    public void EndTurn()
	{
        //Brian Code
        AudioSource audio = GetComponent<AudioSource>();
        //MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE
        //MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 
        GameObject gameobject = GameObject.FindWithTag("Brian2");
        PlayerISS yetAnotherScript;
        yetAnotherScript = gameobject.GetComponent<PlayerISS>();
        yetAnotherScript.takedamage(2);

        //Joe
        MasterControl.control.currGame.EndTurn();
	}

    public void Button1()
    {
        //Brian Code //test //test2
        AudioSource audio = GetComponent<AudioSource>();
        //MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE
        //MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 
        GameObject gameobject = GameObject.FindWithTag("Brian2");
        PlayerISS yetAnotherScript;
        yetAnotherScript = gameobject.GetComponent<PlayerISS>();
        yetAnotherScript.takedamage(decrementa);

        //Joe
        //MasterControl.control.currGame.EndTurn();

        //GameObject gameobject2 = GameObject.FindWithTag("Option3Button");
        //gameobject2.SetActive(false);
    }

    public void Button2()
    {
        //Brian Code
        AudioSource audio = GetComponent<AudioSource>();
        //MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE
        //MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 
        GameObject gameobject = GameObject.FindWithTag("Brian2");
        PlayerISS yetAnotherScript;
        yetAnotherScript = gameobject.GetComponent<PlayerISS>();
        yetAnotherScript.takedamage(decrementb);

        //Joe
        //MasterControl.control.currGame.EndTurn();

        //GameObject gameobject2 = GameObject.FindWithTag("Option3Button");
        //gameobject2.SetActive(false);
    }

    public void Button3()
    {
        //Brian Code
        AudioSource audio = GetComponent<AudioSource>();
        //MasterControl.control.currGame.EndTurn(); //does not work in MasterControl but in MAINTENANCE
        //MasterControl.control.currGame.startEvent(); //does work in MAINTENCE 
        GameObject gameobject = GameObject.FindWithTag("Brian2");
        PlayerISS yetAnotherScript;
        yetAnotherScript = gameobject.GetComponent<PlayerISS>();
        yetAnotherScript.takedamage(decrementc);

        //Joe
        //MasterControl.control.currGame.EndTurn();

        //GameObject gameobject2 = GameObject.FindWithTag("Option3Button");
        //gameobject2.SetActive(false);
    }

}
