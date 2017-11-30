using UnityEngine;
using System.Collections;

/*
 Controls the visibility of a particular game object
 Use in unison with UIController.cs
 Might add codes within UIController.cs to here in order to better streamline the workflow 
*/

public class SettingsPopUp : MonoBehaviour
{
    private int currPlayer = 0;

    public void setCurrPlayer(int count)
    {
        currPlayer = count;
    }

    public void Open()
    {
        Debug.Log("currentPlayer: " + currPlayer);
        if (gameObject.tag == ("info" + (currPlayer + 1)))
            gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
