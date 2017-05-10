using UnityEngine;
using System.Collections;

/*
Handles the most general and basic functions of maintaining the game.
Functions here can be called in other scripts by using MasterControl.control.(insertFunctionHere)
*/

public class MasterControl : MonoBehaviour {

	public static MasterControl control;
	public Maintenance currGame;
	private int numOfPlayers = 3;
	private bool newGame = true;

	void Awake () {
		if (control == null)
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this) 
		{
			Destroy(gameObject);
		}
		//TEMPORARILY HERE vvv
		OnLevelWasLoaded();
	}

	//Will be used to save active games
	public void Save()
	{
		/*
		BinaryFormatter bf = new BinaryFormatter();
		SaveFile = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Create);
		PlayerData data = new PlayerData (animal, weapon, jetpack, skin, animalOwned, weaponOwned, jetpackOwned, skinOwned, money);
		bf.Serialize (SaveFile, data);
		SaveFile.Close ();
		*/
	}

	//Will be used to load inactive games
	public void Load()
	{
		/* --- This is setup for save so do opposite ---
		BinaryFormatter bf = new BinaryFormatter();
		SaveFile = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Create);
		PlayerData data = new PlayerData (animal, weapon, jetpack, skin, animalOwned, weaponOwned, jetpackOwned, skinOwned, money);
		bf.Serialize (SaveFile, data);
		SaveFile.Close ();
		*/
	}

	public void EndTurn()
	{
		Debug.Log("Next Turn");
		currGame.EndTurn();
	}

	void OnLevelWasLoaded()
	{
		if (control == this) 
		{
			if(newGame)
			{
				currGame = new Maintenance();
			}
			else
			{
				//Load Pertinent Data	
			}
		}
	}

	public int getNumOfPlayers()
	{
		return numOfPlayers;
	}
			
}

 
// ---Example of how saving data might work---

/*
[Serializable]
class PlayerData
{
	public int animal;
	public int weapon;
	public int jetpack;
	public int skin;
	public bool[] animalOwned = new bool[StoreConstants.numOfAnimals];
	public bool[] weaponOwned = new bool[StoreConstants.numOfWeapons];
	public bool[] jetpackOwned = new bool[StoreConstants.numOfJetpacks];
	public bool[] skinOwned = new bool[StoreConstants.numOfSkins];
	public int money;
		
	public PlayerData(int animalData, int weaponData, int jetpackData, int skinData, bool[] animalOwnedData, bool[] weaponOwnedData, bool[] jetpackOwnedData, bool[] skinOwnedData, int moneyData)
	{
		animal = animalData;
		weapon = weaponData;
		jetpack = jetpackData;
		skin = skinData;
		animalOwned = (bool[])animalOwnedData.Clone ();
		weaponOwned = (bool[])weaponOwnedData.Clone ();
		jetpackOwned = (bool[])jetpackOwnedData.Clone ();
		skinOwned = (bool[])jetpackOwnedData.Clone ();
		money = moneyData;
	}
}
*/
