using UnityEngine;
using System.Collections;

/*
 Controls the visibility of a particular game object
 Use in unison with UIController.cs
 Might add codes within UIController.cs to here in order to better streamline the workflow 
*/

public class SettingsPopUp : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
