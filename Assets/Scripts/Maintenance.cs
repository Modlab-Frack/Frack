using UnityEngine;
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
    public EventMaintenance events;
    public Event CurrentEvent = null;
    public bool eventOn = false;
    public TurnMovement playerMovement = new TurnMovement();


	//Game Constructor
	public Maintenance()
	{
        Button optionOne = GameObject.FindGameObjectWithTag("Option1Button").GetComponent<Button>();
        optionOne.onClick.AddListener(selectFirstOption);

        Button optionTwo = GameObject.FindGameObjectWithTag("Option2Button").GetComponent<Button>();
        optionTwo.onClick.AddListener(selectSecondOption);

        Button optionThree = GameObject.FindGameObjectWithTag("Option3Button").GetComponent<Button>();
        optionThree.onClick.AddListener(selectThirdOption);

        GameObject eventPopup = GameObject.FindGameObjectWithTag("Event");
        Image eventImage = eventPopup.GetComponent<Image>();
        eventImage.enabled = false;
        gameMap = new Map();
        events = new EventMaintenance();
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
        //CloseEvent();
        currentPlayer += 1;

        if (currentPlayer == 3)
            playerMovement.movePlayer1();

        else if (currentPlayer == 1)
            playerMovement.movePlayer2();

        else if (currentPlayer == 2)
            playerMovement.movePlayer3();

        currentTurn += 1;
		if(currentTurn % MasterControl.control.getNumOfPlayers() == 0)
		{
            currentPlayer = 0;
			foreach(GameObject player in players1)//(Player player in players)
			{
                Player temp = player.GetComponent<Player>();
                foreach (Cell mine in temp.playerOwnedCells)//(Cell mine in player.playerOwnedCells)
				{
					if(mine == null)
						break;

                    temp.money += mine.drillTheMines() * 100;

                    //player.money += mine.drillTheMines() * 100;
                    /*
					// WILL WANT TO CHANGE THIS TO GAS ONCE THERES A WAY TO EXCHANGE
					*/
                }
                //Debug.Log(temp.money);
                temp.moneyText.text = temp.money.ToString();
                temp.cellsText.text = temp.cellsOwned.ToString();
            }
            //Event();
			UpdateMainUI();
			currentPlayer = 0;
		}

        eventOn = ShowEvent();
    }

	//Updates Player Scores, we need to at the very least make the text it displays dynamic
	// to number of players
	public void UpdateMainUI()
	{
        //Player curPlayer = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>();
        //curPlayer.moneyText.text = curPlayer.money.ToString();
        //Player temp = MasterControl.control.currGame.players1[0].GetComponent<Player>();

        // temp.moneyText.text = "Test";
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

    public bool ShowEvent()
    {
        
        GameObject eventPopup = GameObject.FindGameObjectWithTag("Event");
        Image eventImage = eventPopup.GetComponent<Image>();


        //eventImage.enabled = true;



        Event eventDesc = events.getRandomEvent();

        if (eventDesc == null)
            return false;

        GameObject gameobject1 = GameObject.FindWithTag("Option1Button");
        //  gameobject1.SetActive(true);
        Button option1a = GameObject.FindGameObjectWithTag("Option1Button").GetComponent<Button>();
        //option1a.enabled = false;
        option1a.interactable = true;

        GameObject gameobject2 = GameObject.FindWithTag("Option2Button");
        // gameobject2.SetActive(true);
        Button option2a = GameObject.FindGameObjectWithTag("Option2Button").GetComponent<Button>();
        option2a.interactable = true;

        GameObject gameobject3 = GameObject.FindWithTag("Option3Button");
        //  gameobject3.SetActive(true);
        Button option3a = GameObject.FindGameObjectWithTag("Option3Button").GetComponent<Button>();
        option3a.interactable = true;




        CurrentEvent = eventDesc;
        eventImage.enabled = true;
        Text my_text = GameObject.FindGameObjectWithTag("EventDescription").GetComponent<Text>();

        for(int i = 1; i <= 3; i++)
        {
            string romanNumeral = "";

            if (i == 1)
                romanNumeral = "I. ";

            else if (i == 2)
                romanNumeral = "II. ";

            else if (i == 3)
                romanNumeral = "III. ";

            string tag = "Option" + i.ToString() + "Button";
            Button option = GameObject.FindGameObjectWithTag(tag).GetComponent<Button>();
            option.GetComponentInChildren<Text>().text = romanNumeral + eventDesc.options[i - 1].optionDescription;
        }
        //Button option1Button = GameObject.FindGameObjectWithTag("Option1Button").GetComponent<Button>();
        //option1Button.GetComponentInChildren<Text>().text = "I. " + eventDesc.options[0].optionDescription;
        //Text option1 = GameObject.FindGameObjectWithTag("Option1").GetComponent<Text>();
        //Text option2 = GameObject.FindGameObjectWithTag("Option2").GetComponent<Text>();
        my_text.text = eventDesc.eventDescription;
        //option1.text = "I. " + eventDesc.options[0].optionDescription;
        //option2.text = "II. " + eventDesc.options[1].optionDescription;

        return true;
    }

    public bool checkRequirement(Option chosenOption)
    {
        Debug.Log("Player Number " + MasterControl.control.currGame.currentPlayer.ToString());
        Player curPlayer = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>();

        if (curPlayer.lawyers < (-1 * chosenOption.legalReq))
            return false;

        if (curPlayer.publicity < (-1 * chosenOption.prReq))
            return false;

        if (curPlayer.research < (-1 * chosenOption.prReq))
            return false;

        int rng = Random.Range(0, 100);

        if (rng <= chosenOption.chance)
            return false;

        return true;
    }

    public void updateStats()
    {
        Option chosenOption = CurrentEvent.options[events.pick];

        if (!checkRequirement(chosenOption))
        {
            Debug.Log("Failed");
            return;
        }

        Debug.Log("Success");
        Player curPlayer = MasterControl.control.currGame.players1[MasterControl.control.currGame.currentPlayer].GetComponent<Player>();
        Debug.Log("Original Research Score: " + curPlayer.research.ToString());
        curPlayer.research += chosenOption.researchEffect;
        Debug.Log("New Research Score: " + curPlayer.research.ToString());
        curPlayer.publicity += chosenOption.prEffect;
        curPlayer.lawyers += chosenOption.legalEffect;
        curPlayer.money += (curPlayer.money * (float)chosenOption.moneyPercentChange);

        //Update Doomcounter here

    }

    public bool CloseEvent()
    {
        updateStats();
        GameObject eventPopup = GameObject.FindGameObjectWithTag("Event");
        Image eventImage = eventPopup.GetComponent<Image>();


        //eventImage.enabled = false;




        if (eventImage.enabled == true)
        {
            Text my_text = GameObject.FindGameObjectWithTag("EventDescription").GetComponent<Text>();
            Text option1 = GameObject.FindGameObjectWithTag("Option1").GetComponent<Text>();
            Text option2 = GameObject.FindGameObjectWithTag("Option2").GetComponent<Text>();
            Text option3 = GameObject.FindGameObjectWithTag("Option3").GetComponent<Text>();
            //Text option2 = GameObject.FindGameObjectWithTag("Option2").GetComponent<Text>();
            my_text.text = "";
            option1.text = "";
            option2.text = "";
            option3.text = "";
            eventImage.enabled = false;


            Button option1a = GameObject.FindGameObjectWithTag("Option1Button").GetComponent<Button>();
            //option1a.enabled = false;
            option1a.interactable = false;
            // option1a.alpha = 0f;

            Button option2a = GameObject.FindGameObjectWithTag("Option2Button").GetComponent<Button>();
            option2a.interactable = false;

            Button option3a = GameObject.FindGameObjectWithTag("Option3Button").GetComponent<Button>();
            option3a.interactable = false;

            //Image option1aa= GameObject.FindGameObjectWithTag("Option1Button").GetComponent<Image>();
            //option1aa.gameObject.SetActive(false);
            //option1aa.alpha = 0f;

        }

        return false;
    }


    public void selectFirstOption()
    {
        Debug.Log("Clicked 1");
        events.pick = 0;
        CloseEvent();
        /*
        GameObject gameobject1 = GameObject.FindWithTag("Option1Button");
        gameobject1.SetActive(false);
        GameObject gameobject2 = GameObject.FindWithTag("Option2Button");
        gameobject2.SetActive(false);
        GameObject gameobject3 = GameObject.FindWithTag("Option3Button");
        gameobject3.SetActive(false);
        */
    }

    public void selectSecondOption()
    {
        Debug.Log("Clicked 2");
        events.pick = 1;
        CloseEvent();

        /*
        GameObject gameobject1 = GameObject.FindWithTag("Option1Button");
        gameobject1.SetActive(false);
        GameObject gameobject2 = GameObject.FindWithTag("Option2Button");
        gameobject2.SetActive(false);
        GameObject gameobject3 = GameObject.FindWithTag("Option3Button");
        gameobject3.SetActive(false);
        */
    }

    public void selectThirdOption()
    {
        Debug.Log("Clicked 3");
        events.pick = 2;
        CloseEvent();

        /*
        GameObject gameobject1 = GameObject.FindWithTag("Option1Button");
        gameobject1.SetActive(false);
        GameObject gameobject2 = GameObject.FindWithTag("Option2Button");
        gameobject2.SetActive(false);
        GameObject gameobject3 = GameObject.FindWithTag("Option3Button");
        gameobject3.SetActive(false);
        */
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
