﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
In charge of actual gameplay this class should be more a main picture type thing dealing with turns and game flow
If not on a gameobject then we can only access it through mastercontrol
*/

public class Maintenance {

	public Map gameMap;
    //public Player[] players;
    public GameObject[] players1;
	public int currentPlayer = 0;
	public int currentTurn = 0;

	//Game Constructor
	public Maintenance()
	{
		gameMap = new Map();
		//players = new Player[MasterControl.control.getNumOfPlayers()];
        players1 = new GameObject[MasterControl.control.getNumOfPlayers()];
        for (int i = 0; i < MasterControl.control.getNumOfPlayers(); i++)
		{
            //Player play = new Player();

            // play.player = GameObject.FindGameObjectWithTag("Player" + (i + 1));
            //players[i] = new Player();
            players1[i] = GameObject.FindGameObjectWithTag("Player" + (i + 1));
            Player temp = players1[i].GetComponent<Player>();
            //Debug.Log(temp.publicity);
        }
		UpdateMainUI();
	}

	//Ends a players turn
	public void EndTurn()
	{
		currentPlayer += 1;
		currentTurn += 1;
		if(currentTurn % MasterControl.control.getNumOfPlayers() == 0)
		{
			foreach(GameObject player in players1)//(Player player in players)
			{
                Debug.Log("Publicity: " + player.GetComponent<Player>().publicity);
                Player temp = player.GetComponent<Player>();
                foreach (Cell mine in temp.playerOwnedCells)//(Cell mine in player.playerOwnedCells)
				{
					if(mine == null)
					{
						break;
					}
                    temp.money += mine.drillTheMines() * 100;
					//player.money += mine.drillTheMines() * 100;
					/*
					// WILL WANT TO CHANGE THIS TO GAS ONCE THERES A WAY TO EXCHANGE
					*/
				}
			}
			Event();
			UpdateMainUI();
			currentPlayer = 0;
		}
	}

	//Updates Player Scores, we need to at the very least make the text it displays dynamic
	// to number of players
	public void UpdateMainUI()
	{
		/*
		string playerUIText = "Player 1: $" + players[0].money + ", G " + players[0].gas + "\n";
		for(int i = 1; i < MasterControl.control.getNumOfPlayers(); i++)
		{
			playerUIText += "Player " + (i+1) + ": $" + players[i].money + ", G " + players[i].gas + "\n";
		}
		Text textValue1 = GameObject.FindGameObjectsWithTag("PlayerInfo")[0].GetComponentInChildren<Text>();
		textValue1.text = playerUIText;
		*/
	}

	// EventSystem??
	public void Event()
	{

	}
}

/* ---Old Code For Reference---

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upkeep : MonoBehaviour {

	// How many players?
	public int totalPlayers = 3;
	
	// Metamap size
	public int totalCellsWide = 50;
	public int totalCellsTall = 15;
	
	// Stats array sizes
	private int totalPlayerStats = 8;
	private int totalCellStats = 14;

	// Player Stats Array Index
	private int money = 0;
	private int gas = 1;
	private int share = 2;
	private int wells = 3;
	private int lawyers = 4;
	private int research = 5;
	private int publicity = 6;

	// Initial Player Values
	public int initialMoney = 1000;
	public int initialGas = 0;
	public int initialWells = 0;
	public int initialLawyers = 0;
	public int initialResearch = 0;
	public int initialPublicity = 0;

	// Cell Identity
	public int xPos = 0;
	public int yPos = 0;
	public int cellNumber = 0;
	public Object newCell;
	
	// Cell Stats Array Index
	private int owner = 0;
	private int phase = 1;
	private int richness = 2; // Richness is 0 or 50 to 100

	private int yield1 = 3;
	private int yield2 = 4;
	private int yield3 = 5;
	private int yield4 = 6;
	private int yield5 = 7;
	
	private int difficulty = 8; // From 1 to 100
	private int regulation = 9; // From 1 to 100
	
	// A hard-coded, non-procedural 2d arrays that gets added to the metamap
	private int state = 10;
	private int zoning = 11;	// ***** 1 = rural, 2 = suburban, 3 = urban, etc.
	private int environment = 12; // ***** 1 = forest, 2 = marine, 3 = desert, etc.
	private int elevation = 13; // ***** 1 = sealevel, 2 = etc.

	// Cell Prefab Definition
	public Transform cell;
	
	public float[,] playerStats;
	public int[,,] mapStats;
	
	// Game State
	public int marketPrice = 100;
	public int currentPlayer = 1;
	public int currentTurn = 1;
	public int turnOver = 0;
	
	public AudioClip cash;
	private AudioSource source;
	public GameObject playerInfo;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	
		// produce 
		playerStats = new float[totalPlayers+1,totalPlayerStats+1];
		mapStats = new int[totalCellsWide+1,totalCellsTall+1,totalCellStats+1];
		
		// generates player stats
		for (int i = 0; i <= totalPlayers; i++) {
			playerStats[i,money] = initialMoney;
			playerStats[i,gas] = initialGas;
			playerStats[i,wells] = initialWells;
			playerStats[i,share] = playerStats[i,wells] * marketPrice;
			playerStats[i,lawyers] = initialLawyers;
			playerStats[i,research] = initialResearch;
			playerStats[i,publicity] = initialPublicity;
		}
		
		// generates metamap
		for (int j = 0; j < totalCellsWide; j++) {
			for (int k = 0; k < totalCellsTall; k++) {
				mapStats[j,k,owner] = 0;
				mapStats[j,k,phase] = 0;
				mapStats[j,k,richness] = calculateInitialRichness();
				mapStats[j,k,yield1] = mapStats[j,k,richness];
				mapStats[j,k,yield2] = mapStats[j,k,richness];
				mapStats[j,k,yield3] = mapStats[j,k,richness];
				mapStats[j,k,yield4] = mapStats[j,k,richness];
				mapStats[j,k,yield5] = mapStats[j,k,richness];
				mapStats[j,k,difficulty] = calculateInitialDifficulty();
				mapStats[j,k,regulation] = calculateInitialRegulation();
			}
		}
		
		// generates graphic map
		for (int m = 0; m < totalCellsWide; m++) {
			for (int n = 0; n < totalCellsTall; n++) {
				xPos = m;
				yPos = n;
				newCell = Instantiate(cell, new Vector3(m, 0, n), Quaternion.identity);
				newCell.name = "Cell "+m+", "+n;
				cellNumber++;
			}
		}		
	}
	
	void Update () {
		if (turnOver == 1){
			Event();
			turnOver = 0;
		}
	}
	
	private int calculateInitialRichness() {
		int hasShale = Random.Range(0,2);
		int tunedShale = 0;
		if (hasShale == 1) {
			tunedShale = Random.Range(50,101);
		}
		return tunedShale;
	}
	
	private int calculateInitialDifficulty() {
		return Random.Range(0,101);
	}

	private int calculateInitialRegulation() {
		return Random.Range(0,51);
	}
	
	void Event () {
		// perform event
		// call upkeep
		Debug.Log("Event Phase!");
		EndTurn();
	}

	void EndTurn () {
		// perform upkeep
		// update scoreboard
		// set player turn to 1
		Debug.Log("Upkeep Phase!");
		
		for (int y = 0; y < totalCellsWide; y++) {
			for (int z = 0; z < totalCellsTall; z++) {
				if (mapStats[y,z,owner] != 0) {
					for (int x = mapStats[y,z,phase]-yield1+1; x > 0; x--) {
						playerStats[mapStats[y,z,owner],money] += 1000; //* mapStats[y,z,x+yield1];//(int)(mapStats[y,z,x+yield1]*.20f * marketPrice * ((100-mapStats[y,z,difficulty])/100) * ((100-mapStats[y,z,regulation])/100));
						Debug.Log("Player " + mapStats[y,z,owner] + "'s money is " + playerStats[mapStats[y,z,owner],money] + ".");
						//mapStats[y,z,x+yield1] -= 20;//(int)(mapStats[y,z,yield1]*.20f);
					}
					if (mapStats[y,z,phase]==1) {
						//mapStats[y,z,phase] += 1;
						// Find the cell, and flip the graphic here!
					}
				}
			}
		}
		//Update scoreboard
		source.PlayOneShot(cash,1);
		playerInfo = GameObject.Find("PlayerInfo");
			Text[] textValue = playerInfo.GetComponentsInChildren<Text>();
			textValue[0].text = 
				"Player 1: $" + playerStats[1,money] + ", G" + playerStats[1,gas] + "\n" +
				"Player 2: $" + playerStats[2,money] + ", G" + playerStats[2,gas] + "\n" +
				"Player 3: $" + playerStats[3,money] + ", G" + playerStats[3,gas];
	}
}
*/
