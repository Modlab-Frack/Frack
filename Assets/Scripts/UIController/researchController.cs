using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class researchController : MonoBehaviour {

    [SerializeField]
    private int countResearch = 0;
    [SerializeField]
    private SettingsPopUp settingsPopup;

    //All popups initialized to "Close" at the start of the game.
    void Start()
    {
        //Debug.Log(countResearch);
        settingsPopup.Close();
    }

    public void OnResearchOpenSettings()
    {
        Debug.Log(countResearch);
        if (countResearch == 0)
            settingsPopup.Open();

        else
            settingsPopup.Close();

        countResearch = (countResearch + 1) % 2;
    }
}
