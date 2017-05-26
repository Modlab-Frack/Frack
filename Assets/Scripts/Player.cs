using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
Will mainly contains stats related to players, possibly some helper functions
*/

public class Player : MonoBehaviour
{
    //public GameObject player; 
	public float money = 1000f;
	public int gas = 0;
	public int share = 0;
	public int wells = 0;
	public int lawyers = 0;
	public int research = 0;
	public int publicity = 0;
	public int cellsOwned = 0;
    public float legalUpgradeCost = 1;
    public float publicityUpgradeCost = 1;
    public float researchUpgradeCost = 1;
    public Text moneyText;
	public Cell[] playerOwnedCells = new Cell[200];
}
