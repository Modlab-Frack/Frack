using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
 Master control for the UI interaction.
 Use in relation with other UI scripts (SettingsPopUp.cs, ButtonScript.cs)
 Controls the overall flow of the UI by calling functions from other scripts
*/
public class UIController : MonoBehaviour
{
    [SerializeField]
    private SettingsPopUp settingsPopup;
    private Image legalLevelDisplay; //Use to display the right level bar for the legal stat

    private int owner; //Use to initialize the owner of the turn

    private int countOne = 0;
    private int countTwo = 0;
    private int countThree = 0;

    private int countLegal = 0;
    private int countResearch = 0;

    //Variables use to update the price of upgrade like how the cost of the cells are implemented, see Cell.cs
    //A better formulation might be need to increment the cost
    //public float currentCost = 1;
    public float upgrade1Cost = 100;
    public float upgrade2Cost = 90;
    public float upgrade3Cost = 80;
    public float upgrade4Cost = 70;
    public float upgrade5Cost = 60;
    public float upgrade6Cost = 50;
    public float upgrade7Cost = 25;
    public float upgrade8Cost = 12;
    public float upgrade9Cost = 6;
    public float upgrade10Cost = 3;

    //All popups initialized to "Close" at the start of the game.
    void Start()
    {
        settingsPopup.Close();
    }

    //Function to control the popup for player1 stats.
    public void OnPlayerOneOpenSettings()
    {
        owner = MasterControl.control.currGame.currentPlayer;

        //Popup will only show when countOne is 0 and it is currently player1's turn (owner - 1)
        if (countOne == 0 && owner == 0)
            settingsPopup.Open();

        else
            settingsPopup.Close();

        if (owner == 0)
            countOne = (countOne + 1) % 2;
        //Debug.Log("Publicity: " + MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity);
    }

    public void OnPlayerTwoOpenSettings()
    {
        owner = MasterControl.control.currGame.currentPlayer;

        //Popup will only show when countOne is 0 and it is currently player1's turn (owner - 1)
        if (countTwo == 0 && owner == 1)
            settingsPopup.Open();

        else
            settingsPopup.Close();

        if (owner == 1)
            countTwo = (countTwo + 1) % 2;
        //Debug.Log("Publicity: " + MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity);
    }

    public void OnPlayerThreeOpenSettings()
    {
        owner = MasterControl.control.currGame.currentPlayer;

        //Popup will only show when countOne is 0 and it is currently player1's turn (owner - 1)
        if (countThree == 0 && owner == 2)
            settingsPopup.Open();

        else
            settingsPopup.Close();

        if(owner == 3)
            countThree = (countThree + 1) % 2;
        //Debug.Log("Publicity: " + MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity);
    }

    //Function to control the popup for the legal upgrade setting.
    public void OnLegalOpenSettings()
    {
        if (countLegal == 0)
            settingsPopup.Open();

        else
            settingsPopup.Close();

        countLegal = (countLegal + 1) % 2;
    }

    //Function use to increment the legal stat
    public void incrementLegal()
    {
        if (MasterControl.control.currGame.players1[owner].GetComponent<Player>().lawyers > 10)
        {
            //Error Popup (Can't exceed 10 [as of now])
            return;
        }

        owner = MasterControl.control.currGame.currentPlayer;
        MasterControl.control.currGame.players1[owner].GetComponent<Player>().lawyers++;
        Debug.Log("Legal: " + MasterControl.control.currGame.players1[owner].GetComponent<Player>().lawyers);
        updateLegalCost(MasterControl.control.currGame.players1[owner].GetComponent<Player>().lawyers, owner);
    }

    /*
    Function use to update the cost of the legal upgrade according to the level of the user
    Might need to come up with a better formula to increase the cost per level
    */
    public void updateLegalCost(int level, int player)
    {
        float currCost = MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost;

        switch (level)
        {
            case 0:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade1Cost;
                break;

            case 1:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade2Cost;
                break;

            case 2:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade3Cost;
                break;

            case 3:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade4Cost;
                break;

            case 4:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade5Cost;
                break;

            case 5:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade6Cost;
                break;

            case 6:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade7Cost;
                break;

            case 7:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade8Cost;
                break;

            case 8:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade9Cost;
                break;

            case 9:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().legalUpgradeCost = currCost * upgrade10Cost;
                break;

        }
    }

    //Function use to display the cost of the upgrade on the legal upgrade popup
    public void displayLegalPrice()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        Text text1 = GameObject.FindGameObjectsWithTag("legalPrice")[0].GetComponent<Text>();
        text1.text = "";
        text1.text = "Invest $" + MasterControl.control.currGame.players1[owner].GetComponent<Player>().legalUpgradeCost;

    }
    /*
     These functions are use to display the statistic and information for each player
     Will need to use tags and also get information from Player.cs and Cell.cs in order to 
     display all the necessary information
     Overall logic should be similar to the functions above.

    public void displayPlayerOneInfo()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        Text text1 = GameObject.FindGameObjectsWithTag("researchPrice")[0].GetComponent<Text>();
        text1.text = "";
        text1.text = "Invest $" + MasterControl.control.currGame.players[owner].researchUpgradeCost;
    }

    public void displayPlayerTwoInfo()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        Text text1 = GameObject.FindGameObjectsWithTag("researchPrice")[0].GetComponent<Text>();
        text1.text = "";
    }

    public void displayPlayerThreeInfo()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        Text text1 = GameObject.FindGameObjectsWithTag("researchPrice")[0].GetComponent<Text>();
        text1.text = "";
    }
    */

}