using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
Core class that handles all the attributes a given cell might have including their stats and calculations
*/

public class Cell : MonoBehaviour{

	private Object UILight;
	private Image tileDisplay;

	// Variables for holding the cell's ID
	public int xPos = 0;
	public int yPos = 0;

	public int drillSpeed = 1;

	public bool isEmpty = false;
	private int owner = -1;
	private int phase = 0;
	private int richness = 0; // Richness is 0 or 50 to 100
	private int Mine1 = 0;
	private int Mine2 = 0;
	private int Mine3 = 0;
	private int Mine4 = 0;
	private int Mine5 = 0;	
	private float difficulty = 0; // From 2 to 200
	private int environment = 0; // From 1 to 100
	private int regulation = 0; // From 1 to 100
	private int readyTurn = 0;
	//private int state = 0;
	//private int zoning = 0;	// ***** 1 = rural, 2 = suburban, 3 = urban, etc.
	//private int environment = 0; // ***** 1 = forest, 2 = marine, 3 = desert, etc.
	//private int elevation = 0; // ***** 1 = sealevel, 2 = etc.
	
	// Click Costs
	public float currentCost = 0;
	public float surveyingCost = 10;
	public float drillingCost = 100;
	public float fracking1Cost = 100;
	public float fracking2Cost = 50;
	public float fracking3Cost = 25;
	public float fracking4Cost = 12;
	public float fracking5Cost = 6;

	// Use this for initialization
	public void SetXY(int x,int y)
	{
		xPos = x;
		yPos = y;
	}
	
	void OnMouseEnter() {
        //Update Game UI
        UILight = Instantiate(Resources.Load("Light"), new Vector3(xPos, 0, yPos), Quaternion.identity);
        Text textValue1 = GameObject.FindGameObjectsWithTag("CellInfo")[0].GetComponent<Text>();
		textValue1.text = 
			//"Cell ID: " + xPos + ", " + yPos + "\n" +
			//"Owner:  " + owner + "\n" +
			"Phase:   " + phase + "\n" +
			"Yield:   " + "\n" +
			"Ease:    " + xPos + "," + yPos + "\n" +
			"Policy:  " + "\n" +
			"Price:   " + currentCost;
        Text textValue2 = GameObject.FindGameObjectsWithTag("CellInfoOwner")[0].GetComponent<Text>();
        textValue2.text =
            "Player " + (owner + 1);
        tileDisplay = GameObject.FindGameObjectWithTag("TileDisplay").GetComponent<Image>();
        tileDisplay.enabled = true;
        if (owner == MasterControl.control.currGame.currentPlayer && phase >= 1) {
            
			textValue1.text = 
				//"Cell ID: " + xPos + ", " + yPos + "\n" +
				//"Owner: Player " + owner + "\n" +
				"Phase:   " + phase + "\n" +
				"Yield:   " + richness + "\n" +
				"Ease:    " + xPos + "," + yPos + "\n" +
				"Policy:  " + regulation + "\n" +
				"Price:   " + currentCost;

            textValue2.text =
            "Player " + (owner + 1);
            tileDisplay = GameObject.FindGameObjectWithTag("TileDisplay").GetComponent<Image>();
            tileDisplay.enabled = true;
        }
	}

	void OnMouseExit() {
		//GUI EFFECTS
		Destroy(UILight);
    }

	void OnMouseUp() {
		if(MasterControl.control.currGame.currentTurn >= readyTurn)
		{
			if(owner == -1)
			{
                //Survey/Buy
                Debug.Log(MasterControl.control.currGame.currentPlayer);
				if(MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money >= currentCost)
				{
					owner = MasterControl.control.currGame.currentPlayer;
					MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().playerOwnedCells[MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().cellsOwned++] = this;
                    int cell = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().cellsOwned;
                    MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().cellsText.text = cell.ToString();
                    MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money -= currentCost;
                    float money = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money;
                    MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().moneyText.text = money.ToString();
                    MasterControl.control.currGame.UpdateMainUI();
					ChangeColor(owner);
					GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.125f, 0.0f));
					readyTurn = MasterControl.control.currGame.currentTurn - owner + (MasterControl.control.getNumOfPlayers()*1);
					SetDifficulty();
				}
				
			}
			else
			{
				if(owner == MasterControl.control.currGame.currentPlayer && !isEmpty)
				{
					switch(phase)
					{
						case 1:
						{
							if(MasterControl.control.currGame.players1[owner].GetComponent<Player>().money >= currentCost)
							{
								GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.375f, 0.0f));
								MasterControl.control.currGame.players1[owner].GetComponent<Player>().money -= currentCost;
                                MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money -= currentCost;
                                float money = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money;
                                MasterControl.control.currGame.UpdateMainUI();
								readyTurn = MasterControl.control.currGame.currentTurn - owner + (MasterControl.control.getNumOfPlayers()*2);
								SetDifficulty();
							}
							break;
						}
						case 2:
						{
							if(MasterControl.control.currGame.players1[owner].GetComponent<Player>().money >= currentCost)
							{
								GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.5f, 0.0f));
								MasterControl.control.currGame.players1[owner].GetComponent<Player>().money -= currentCost;
                                MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money -= currentCost;
                                float money = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money;
                                MasterControl.control.currGame.UpdateMainUI();
								readyTurn = MasterControl.control.currGame.currentTurn - owner + (MasterControl.control.getNumOfPlayers()*2);
								SetDifficulty();
							}
							break;
						}
						case 3:
						{
							if(MasterControl.control.currGame.players1[owner].GetComponent<Player>().money >= currentCost)
							{
								GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.625f, 0.0f));
								MasterControl.control.currGame.players1[owner].GetComponent<Player>().money -= currentCost;
                                MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money -= currentCost;
                                float money = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money;
                                MasterControl.control.currGame.UpdateMainUI();
								readyTurn = MasterControl.control.currGame.currentTurn - owner + (MasterControl.control.getNumOfPlayers()*2);
								SetDifficulty();
							}
							break;
						}
						case 4:
						{
							if(MasterControl.control.currGame.players1[owner].GetComponent<Player>().money >= currentCost)
							{
								GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.75f, 0.0f));
								MasterControl.control.currGame.players1[owner].GetComponent<Player>().money -= currentCost;
                                MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money -= currentCost;
                                float money = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money;
                                MasterControl.control.currGame.UpdateMainUI();
								readyTurn = MasterControl.control.currGame.currentTurn - owner + (MasterControl.control.getNumOfPlayers()*2);
								SetDifficulty();
							}
							break;
						}
						case 5:
						{
							if(MasterControl.control.currGame.players1[owner].GetComponent<Player>().money >= currentCost)
							{
								GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.875f, 0.0f));
								MasterControl.control.currGame.players1[owner].GetComponent<Player>().money -= currentCost;
                                MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money -= currentCost;
                                float money = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>().money;
                                MasterControl.control.currGame.UpdateMainUI();
								readyTurn = MasterControl.control.currGame.currentTurn - owner + (MasterControl.control.getNumOfPlayers()*2);
								SetDifficulty();
							}
							break;
						}
						default:
						{
							//Can't be interacted with
							break;
						}
					}
				}
			}
		}
		//PlaySound(Sound) <-- Click Sound
	}

	public void SetEnvironment(int theEnvironment)
	{
		environment = theEnvironment;
	}

	public void SetPolicy(int thePolicy)
	{
		regulation = thePolicy;
	}

	//Sets difficulty with optional changes in difficulty factors
	public void SetDifficulty(int theEnvironment = -1,int theRegulation = -1)
	{
		if(theRegulation != -1)
		{
			SetPolicy(theRegulation);
		}
		if(theEnvironment != -1)
		{
			SetEnvironment(theEnvironment);
		}

		difficulty = (float)regulation + (float)environment;
		switch(phase)
		{
			case 0:
			{
				currentCost = surveyingCost * (1f+(difficulty)/100f);
				break;
			}
			case 1:
			{
				currentCost = drillingCost * (1f+(difficulty)/100f);
				break;
			}
			case 2:
			{
				currentCost = fracking1Cost * (1f+(difficulty)/100f);
				break;
			}
			case 3:
			{
				currentCost = fracking2Cost * (1f+(difficulty)/100f);
				break;
			}
			case 4:
			{
				currentCost = fracking3Cost * (1f+(difficulty)/100f);
				break;
			}
			case 5:
			{
				currentCost = fracking4Cost * (1f+(difficulty)/100f);
				break;
			}
			case 6:
			{
				currentCost = fracking5Cost * (1f+(difficulty)/100f);
				break;
			}
			default:
			{
				currentCost = 0f;
				break;
			}
		}
	}

	//Establishes the content of each mine
	public void EstablishRichness(int theRichness)
	{
		richness = theRichness;
		if(richness == 0)
		{
			isEmpty = true;
		}
		else
		{
			Mine1 = Random.Range(1,richness-1);
			Mine2 = Random.Range(1,richness-Mine1);
			Mine3 = Random.Range(1,richness-(Mine1+Mine2));
			Mine4 = Random.Range(1,richness-(Mine1+Mine2+Mine3));
			Mine5 = richness - (Mine1+Mine2+Mine3+Mine4);
		}
	}

	//Returns gas from drilling
	public int drillTheMines()
	{
		int checkEmpty = 0;
		int gas = 0;
		if(readyTurn == MasterControl.control.currGame.currentTurn)
		{
			phase++;
        }
		if(phase < 2 || isEmpty)
		{
			return 0;
		}
		if(Mine1 > 0)
		{
			Mine1 -=drillSpeed;
			gas += Mathf.Min(drillSpeed,Mine1);
		}
		else
		{
			checkEmpty++;
		}
		if(phase < 3)
		{
			return gas;
		}
		if(Mine2 > 0)
		{
			Mine2 -=drillSpeed;
			gas += Mathf.Min(drillSpeed,Mine2);
		}
		else
		{
			checkEmpty++;
		}
		if(phase < 4)
		{
			return gas;
		}
		if(Mine3 > 0)
		{
			Mine3 -=drillSpeed;
			gas += Mathf.Min(drillSpeed,Mine3);
		}
		else
		{
			checkEmpty++;
		}
		if(phase < 5)
		{
			return gas;
		}
		if(Mine4 > 0)
		{
			Mine4 -=drillSpeed;
			gas += Mathf.Min(drillSpeed,Mine4);
		}
		else
		{
			checkEmpty++;
		}
		if(phase < 6)
		{
			return gas;
		}
		if(Mine5 > 0)
		{
			Mine5 -=drillSpeed;
			gas += Mathf.Min(drillSpeed,Mine5);
		}
		else
		{
			checkEmpty++;
		}
		if(checkEmpty == 5)
		{
			isEmpty = true;
		}
		return gas;
	}

	void ChangeColor(int Player)
	{
		switch(Player)
		{
			case 0:
				GetComponent<Renderer>().material.color = Color.red;
			break;
			case 1:
				GetComponent<Renderer>().material.color = Color.blue;
			break;
			case 2:
				GetComponent<Renderer>().material.color = Color.yellow;
			break;
		}
	}

	public int getRichness()
	{
		return richness;
	}
}


/* ---Old Code for Reference---

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CellScript : MonoBehaviour {

	// Connect this script to the master
	public GameObject master;
	public AudioClip click;
	private AudioSource source;
	public GameObject light;
	private Object newLight;
	public GameObject cellInfo;
	public GameObject playerInfo;
	
	// Variables for holding the cell's ID
	public int xPos = 0;
	public int yPos = 0;

	// ###### Copy these variables from master to sync up the metamap
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
	private int state = 10;
	private int zoning = 11;	// ***** 1 = rural, 2 = suburban, 3 = urban, etc.
	private int environment = 12; // ***** 1 = forest, 2 = marine, 3 = desert, etc.
	private int elevation = 13; // ***** 1 = sealevel, 2 = etc.
	
	// Player Stats Array Index
	private int money = 0;
	private int gas = 1;
	private int share = 2;
	private int wells = 3;
	private int lawyers = 4;
	private int research = 5;
	private int publicity = 6;
	
	// Click Costs
	public int surveyingCost = 10;
	public int drillingCost = 100;
	public int fracking1Cost = 100;
	public int fracking2Cost = 50;
	public int fracking3Cost = 25;
	public int fracking4Cost = 12;
	public int fracking5Cost = 6;
	
	// Tracking Info
	public int currentPlayer = 0;
	public int currentTurn = 0;
	public int thisTurn = 0;
	public int currentCost = 0;
	
	// Use this for initialization
	void Awake () {
	
		//attach source and master
		source = GetComponent<AudioSource>();
		master = GameObject.Find("Master");
		
		//first get the current x and y positions from the master
		xPos = master.GetComponent<Upkeep>().xPos;
		yPos = master.GetComponent<Upkeep>().yPos;
		
		currentCost = surveyingCost;
	}
	
	void OnMouseEnter() {
		cellInfo = GameObject.Find("CellInfo");
		Text[] textValue1 = cellInfo.GetComponentsInChildren<Text>();
		textValue1[0].text = 
			"Cell ID: " + xPos + ", " + yPos + "\n" +
			"Owner:  " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] + "\n" +
			"Phase:   " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] + "\n" +
			"Yield:   " + "\n" +
			"Ease:    " + "\n" +
			"Policy:  " + "\n" +
			"Price:   " + currentCost;
		if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner]) {
			textValue1[0].text = 
				"Cell ID: " + xPos + ", " + yPos + "\n" +
				"Owner:  " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] + "\n" +
				"Phase:   " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] + "\n" +
				"Yield:   " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,richness] + "\n" +
				"Ease:    " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,difficulty] + "\n" +
				"Policy:  " + master.GetComponent<Upkeep>().mapStats[xPos,yPos,regulation] + "\n" +
				"Price:    " + currentCost;
		}
		newLight = Instantiate(light, new Vector3(xPos, 0, yPos), Quaternion.identity);
    }
    
    void OnMouseExit() {
    	Destroy(newLight);
    }
    
    void OnMouseUp() {
    	currentPlayer = master.GetComponent<Upkeep>().currentPlayer;
    	currentTurn = master.GetComponent<Upkeep>().currentTurn;
    	
    	// SURVEYING
    	if (master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] == 0 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= surveyingCost &&
    	thisTurn != currentTurn) {
    		master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= surveyingCost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] = currentPlayer;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 1;
    		
    		if(currentPlayer == 1) {
    			GetComponent<Renderer>().material.color = Color.red;
    		} else if (currentPlayer == 2) {
    			GetComponent<Renderer>().material.color = Color.blue;
    		} else if (currentPlayer == 3) {
    			GetComponent<Renderer>().material.color = Color.yellow;
    		}
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.125f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = drillingCost;
    		thisTurn = currentTurn;
    	
    	// DRILLING
    	} else if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] && 
    	master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] == 1 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= drillingCost &&
    	thisTurn != currentTurn) {
    		master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= drillingCost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 2;
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.25f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = fracking1Cost;
    		thisTurn = currentTurn;
    	
    	// FRACKING1
    	} else if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] &&
    	master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] == 2 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= fracking1Cost &&
    	thisTurn != currentTurn) {
    	    master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= fracking1Cost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 3;
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.375f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = fracking2Cost;
    		thisTurn = currentTurn;
    		
    	// FRACKING2
    	} else if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] &&
    	master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] == 3 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= fracking2Cost &&
    	thisTurn != currentTurn) {
    	    master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= fracking2Cost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 4;
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.5f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = fracking3Cost;  		
    		thisTurn = currentTurn;
    		
    	// FRACKING3
    	} else if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] &&
    	master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] == 4 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= fracking3Cost &&
    	thisTurn != currentTurn) {
    	    master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= fracking3Cost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 5;
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.625f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = fracking4Cost;   		
    		thisTurn = currentTurn;
    		
    	// FRACKING4
    	} else if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] &&
    	master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] == 5 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= fracking4Cost &&
    	thisTurn != currentTurn) {
    	    master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= fracking4Cost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 6;
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.75f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = fracking5Cost;    		
    		thisTurn = currentTurn;
    		
    	// FRACKING5
    	} else if (master.GetComponent<Upkeep>().currentPlayer == master.GetComponent<Upkeep>().mapStats[xPos,yPos,owner] &&
    	master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] == 6 &&
    	master.GetComponent<Upkeep>().playerStats[currentPlayer,money] >= fracking5Cost &&
    	thisTurn != currentTurn) {
    	    master.GetComponent<Upkeep>().playerStats[currentPlayer,money] -= fracking5Cost;
    		master.GetComponent<Upkeep>().mapStats[xPos,yPos,phase] = 7;
    		
    		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.875f, 0.0f));
    		source.PlayOneShot(click,1);
    		currentCost = 0;  		
    		thisTurn = currentTurn;
    	
    	} else {
    		//do nothing
    	}
    	
    	playerInfo = GameObject.Find("PlayerInfo");
			Text[] textValue2 = playerInfo.GetComponentsInChildren<Text>();
			textValue2[0].text = 
				"Player 1: $" + master.GetComponent<Upkeep>().playerStats[1,money] + ", G" + master.GetComponent<Upkeep>().playerStats[1,gas] + "\n" +
				"Player 2: $" + master.GetComponent<Upkeep>().playerStats[2,money] + ", G" + master.GetComponent<Upkeep>().playerStats[2,gas] + "\n" +
				"Player 3: $" + master.GetComponent<Upkeep>().playerStats[3,money] + ", G" + master.GetComponent<Upkeep>().playerStats[3,gas];
    }
	
	void OnTriggerEnter(Collider other){
        Destroy(this.gameObject);
    }
}
*/
