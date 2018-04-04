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
    private Image publicityLevelDisplay; //Use to display the right level bar for the publicity stat
    private Image legalLevelDisplay; //Use to display the right level bar for the legal stat
    private Image researchLevelDisplay; //Use to display the right level bar for the research stat

    private int owner; //Use to initialize the owner of the turn

    private int countOne = 0;
    private int countLegal = 0;

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
    public void OnPlayerOpenSettings()
    {
        owner = MasterControl.control.currGame.currentPlayer;

        //Popup will only show when countOne is 0 and it is currently player1's turn (owner - 1)
        if (countOne == 0 && owner == 0)
            settingsPopup.Open();

        else
            settingsPopup.Close();

        countOne = (countOne + 1) % 2;
        Debug.Log("Publicity: " + MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity);
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

    //Function use to manually close the legal upgrade popup, assigned to the invest button
    public void closeLegalPopUp()
    {
        //settingsPopup.Close();
        //countLegal = (countLegal + 1) % 2;
    }


    //Function use to increment the publicity stat
    public void incrementPublicity()
    {
        //As of right now the max level is 10, an error message should be display if a player attempts
        //to increment their level above 10
        if (MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity > 10)
        {
            //Error Popup (Can't exceed 10 [as of now])
            return;
        }

        owner = MasterControl.control.currGame.currentPlayer;
        MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity++;
        //update the cost for the next upgrade
        updatePublicityCost(MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity, owner);
        Debug.Log(MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicity);
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

    //Function use to increment the research stat
    public void incrementResearch()
    {
        if (MasterControl.control.currGame.players1[owner].GetComponent<Player>().research > 10)
        {
            //Error Popup (Can't exceed 10 [as of now])
            return;
        }

        owner = MasterControl.control.currGame.currentPlayer;
        MasterControl.control.currGame.players1[owner].GetComponent<Player>().research++;
        updateResearchCost(MasterControl.control.currGame.players1[owner].GetComponent<Player>().research, owner);
    }

    /*
     Function use to update the cost of the publicity upgrade according to the level of the user
     Might need to come up with a better formula to increase the cost per level
    */
    public void updatePublicityCost(int level, int player)
    {
        float currCost = MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost;

        switch (level)
        {
            case 0:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade1Cost;
                break;

            case 1:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade2Cost;
                break;

            case 2:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade3Cost;
                break;

            case 3:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade4Cost;
                break;

            case 4:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade5Cost;
                break;

            case 5:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade6Cost;
                break;

            case 6:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade7Cost;
                break;

            case 7:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade8Cost;
                break;

            case 8:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade9Cost;
                break;

            case 9:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().publicityUpgradeCost = currCost * upgrade10Cost;
                break;

        }
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

    /*
    Function use to update the cost of the research upgrade according to the level of the user
    Might need to come up with a better formula to increase the cost per level
    */
    public void updateResearchCost(int level, int player)
    {
        float currCost = MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost;

        switch (level)
        {
            case 0:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade1Cost;
                break;

            case 1:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade2Cost;
                break;

            case 2:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade3Cost;
                break;

            case 3:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade4Cost;
                break;

            case 4:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade5Cost;
                break;

            case 5:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade6Cost;
                break;

            case 6:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade7Cost;
                break;

            case 7:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade8Cost;
                break;

            case 8:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade9Cost;
                break;

            case 9:
                MasterControl.control.currGame.players1[player].GetComponent<Player>().researchUpgradeCost = currCost * upgrade10Cost;
                break;

        }
    }

    //Function use to display the cost of the upgrade on the publicity upgrade popup
    public void displayPublicityPrice()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        //Assign the temp Text variable to the button by finding the game object with the right tag
        Text text1 = GameObject.FindGameObjectsWithTag("publicityPrice")[0].GetComponent<Text>();
        text1.text = "";
        text1.text = "Invest $" + MasterControl.control.currGame.players1[owner].GetComponent<Player>().publicityUpgradeCost;

    }

    //Function use to display the cost of the upgrade on the legal upgrade popup
    public void displayLegalPrice()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        Text text1 = GameObject.FindGameObjectsWithTag("legalPrice")[0].GetComponent<Text>();
        text1.text = "";
        text1.text = "Invest $" + MasterControl.control.currGame.players1[owner].GetComponent<Player>().legalUpgradeCost;

    }

    //Function use to display the cost of the upgrade on the research upgrade popup
    public void displayResearchPrice()
    {
        owner = MasterControl.control.currGame.currentPlayer;
        Text text1 = GameObject.FindGameObjectsWithTag("researchPrice")[0].GetComponent<Text>();
        text1.text = "";
        text1.text = "Invest $" + MasterControl.control.currGame.players1[owner].GetComponent<Player>().researchUpgradeCost;

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