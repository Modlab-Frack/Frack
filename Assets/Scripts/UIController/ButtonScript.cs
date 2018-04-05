using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	public void EndTurn()
	{
		MasterControl.control.currGame.EndTurn();
	}
}
