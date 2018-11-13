using UnityEngine;
using System.Collections;

public class Map {

	public GameObject[,] cells = new GameObject[25,40];

	public Cell getCell(int y,int x)
	{
		return cells[y,x].GetComponent<Cell>();
	}

	public Map()
	{
		State currState = new State();
		for (int m = 1; m < 25; m++)
		 {
			for (int n = 0; n < 39; n++) 
			{
				cells[m,n] = (GameObject)Object.Instantiate(Resources.Load("Cell"));
				cells[m,n].transform.position =  new Vector3(n, 0, m);
				getCell(m,n).SetXY(n,m);
			}
		}

		for(int i = 0; i < 19; i++)
		{
			GameObject.Destroy(cells[1,i]);
			cells[1,i] = null;
		}
		for(int i = 0; i < 18; i++)
		{
			GameObject.Destroy(cells[2,i]);
			cells[2,i] = null;
		}
		for(int i = 0; i < 17; i++)
		{
			GameObject.Destroy(cells[3,i]);
			cells[3,i] = null;
		}
		for(int i = 0; i < 14; i++)
		{
			GameObject.Destroy(cells[4,i]);
			cells[4,i] = null;
		}
		for(int i = 0; i < 13; i++)
		{
			GameObject.Destroy(cells[5,i]);
			cells[5,i] = null;
		}
		for(int i = 0; i < 10; i++)
		{
			GameObject.Destroy(cells[6,i]);
			cells[6,i] = null;
		}
		for(int i = 0; i < 7; i++)
		{
			GameObject.Destroy(cells[7,i]);
			cells[7,i] = null;
		}
		for(int i = 0; i < 4; i++)
		{
			GameObject.Destroy(cells[8,i]);
			cells[8,i] = null;
		}
		for(int i = 0; i < 3; i++)
		{
			GameObject.Destroy(cells[9,i]);
			cells[9,i] = null;
		}
		for(int i = 0; i < 2; i++)
		{
			GameObject.Destroy(cells[10,i]);
			cells[10,i] = null;
		}
		for(int i = 13; i < 36; i++)
		{
			GameObject.Destroy(cells[24,i]);
			cells[24,i] = null;
		}
		GameObject.Destroy(cells[24,0]);
		cells[24,0] = null;
		GameObject.Destroy(cells[24,38]);
		cells[24,38] = null;
		GameObject.Destroy(cells[24,2]);
		cells[24,2] = null;
		GameObject.Destroy(cells[11,0]);
		cells[11,0] = null;
		GameObject.Destroy(cells[22,0]);
		cells[22,0] = null;
		GameObject.Destroy(cells[23,0]);
		cells[23,0] = null;
		GameObject.Destroy(cells[21,0]);
		cells[21,0] = null;
		GameObject.Destroy(cells[22,38]);
		cells[22,38] = null;
		GameObject.Destroy(cells[21,38]);
		cells[21,38] = null;
		for(int i = 22; i < 36; i++)
		{
			GameObject.Destroy(cells[23,i]);
			cells[23,i] = null;
		}
		for(int i = 24; i < 34; i++)
		{
			GameObject.Destroy(cells[22,i]);
			cells[22,i] = null;
		}
		for(int i = 27; i < 33; i++)
		{
			GameObject.Destroy(cells[21,i]);
			cells[21,i] = null;
		}
		GameObject.Destroy(cells[20,26]);
		cells[20,26] = null;
		GameObject.Destroy(cells[20,29]);
		cells[20,29] = null;
		GameObject.Destroy(cells[20,30]);
		cells[20,30] = null;
		GameObject.Destroy(cells[20,31]);
		cells[20,31] = null;
		for(int i = 29; i < 31; i++)
		{
			GameObject.Destroy(cells[19,i]);
			cells[19,i] = null;
		}
		for(int i = 29; i < 30; i++)
		{
			GameObject.Destroy(cells[18,i]);
			cells[18,i] = null;
		}
		GameObject.Destroy(cells[19,26]);
		cells[19,26] = null;
		for(int i = 20; i < 33; i++)
		{
			GameObject.Destroy(cells[1,i]);
			cells[1,i] = null;
		}
		for(int i = 35; i < 39; i++)
		{
			GameObject.Destroy(cells[1,i]);
			cells[1,i] = null;
		}
		for(int i = 20; i < 32; i++)
		{
			GameObject.Destroy(cells[2,i]);
			cells[2,i] = null;
		}
		for(int i = 21; i < 32; i++)
		{
			GameObject.Destroy(cells[3,i]);
			cells[3,i] = null;
		}
		GameObject.Destroy(cells[4,22]);
		cells[4,22] = null;
		for(int i = 27; i < 30; i++)
		{
			GameObject.Destroy(cells[4,i]);
			cells[4,i] = null;
		}
		GameObject.Destroy(cells[5,27]);
		cells[5,27] = null;
		GameObject.Destroy(cells[18,26]);
		cells[18,26] = null;
		for(int i = 5; i < 9; i++)
		{
			GameObject.Destroy(cells[i,33]);
			cells[i,33] = null;
		}
		for(int i = 3; i < 12; i++)
		{
			GameObject.Destroy(cells[i,34]);
			cells[i,34] = null;
		}
		for(int i = 2; i < 19; i++)
		{
			GameObject.Destroy(cells[i,35]);
			cells[i,35] = null;
		}
		for(int i = 2; i < 19; i++)
		{
			GameObject.Destroy(cells[i,36]);
			cells[i,36] = null;
		}
		for(int i = 2; i < 22; i++)
		{
			GameObject.Destroy(cells[i,37]);
			cells[i,37] = null;
		}
		for(int i = 2; i < 21; i++)
		{
			GameObject.Destroy(cells[i,38]);
			cells[i,38] = null;
		}


		int choice = Random.Range(0,2);
		switch(choice)
		{
			case 0: //Complete random distrobution
			{
				for (int m = 0; m < 25; m++)
				{
					for (int n = 0; n < 40; n++) 
					{
						if(cells[m,n] != null)
						{
							int richness = Random.Range(0,101);
							if(richness < 50)
								richness = 0;
							getCell(m,n).EstablishRichness(richness);
						}
					}
				}
				break;
			}
			case 1: //Associated Distrobution
			{
				bool[,] Visited = new bool [25,40];
				Queue MapQueue = new Queue();
				for (int m = 0; m < 25; m++)
				 {
					for (int n = 0; n < 40; n++) 
					{
						Visited[m,n] = false;
					}
				}

				int first = Random.Range(2,33);

				Visited[13,first] = true;
				getCell(13,first).EstablishRichness(Random.Range(50,101));
				MapQueue.Enqueue(getCell(13,first));

				while(MapQueue.Count != 0)
				{
					Cell temp = (Cell)MapQueue.Dequeue();
					if(temp.xPos > 0)
					{
						if(Visited[temp.yPos,temp.xPos - 1] == false)
						{
							if(cells[temp.yPos,temp.xPos - 1] != null)
							{
								Cell temp1 = getCell(temp.yPos,temp.xPos - 1);
								temp1.EstablishRichness(AssociateRichness(temp));
								MapQueue.Enqueue(temp1);
							}
							Visited[temp.yPos,temp.xPos - 1] = true;
						}
					}
					if(temp.xPos < 39)
					{
						if(Visited[temp.yPos,temp.xPos + 1] == false)
						{
							if(cells[temp.yPos,temp.xPos + 1] != null)
							{
								Cell temp1 = getCell(temp.yPos,temp.xPos + 1);
								temp1.EstablishRichness(AssociateRichness(temp));
								MapQueue.Enqueue(temp1);
							}
							Visited[temp.yPos,temp.xPos + 1] = true;
						}
					}
					if(temp.yPos < 24)
					{
						if(Visited[temp.yPos + 1,temp.xPos] == false)
						{
							if(cells[temp.yPos + 1,temp.xPos] != null)
							{
								Cell temp1 = getCell(temp.yPos + 1,temp.xPos);
								temp1.EstablishRichness(AssociateRichness(temp));
								MapQueue.Enqueue(temp1);
							}
							Visited[temp.yPos + 1,temp.xPos] = true;
						}
					}
					if(temp.yPos > 2)
					{
						if(Visited[temp.yPos - 1,temp.xPos] == false)
						{
							if(cells[temp.yPos - 1,temp.xPos] != null)
							{
								Cell temp1 = getCell(temp.yPos - 1,temp.xPos);
								temp1.EstablishRichness(AssociateRichness(temp));
								MapQueue.Enqueue(temp1);
							}
							Visited[temp.yPos - 1,temp.xPos] = true;
						}
					}
				}
				break;
			}
			case 2: //Striped distrobution
			{

				break;
			}
		}
		currState = new California(this);
		currState.setInitialDifficulty();
		currState = new Washington(this);
		currState.setInitialDifficulty();
		currState = new Oregon(this);
		currState.setInitialDifficulty();
		currState = new Nevada(this);
		currState.setInitialDifficulty();
		currState = new Arizona(this);
		currState.setInitialDifficulty();
		currState = new Utah(this);
		currState.setInitialDifficulty();
		currState = new Nevada(this);
		currState.setInitialDifficulty();
		currState = new Colorado(this);
		currState.setInitialDifficulty();
		currState = new Utah(this);
		currState.setInitialDifficulty();
		currState = new Idaho(this);
		currState.setInitialDifficulty();
		currState = new Montana(this);
		currState.setInitialDifficulty();
		currState = new Wyoming(this);
		currState.setInitialDifficulty();
		currState = new Colorado(this);
		currState.setInitialDifficulty();
		currState = new NewMexico(this);
		currState.setInitialDifficulty();
		currState = new Texas(this);
		currState.setInitialDifficulty();
		currState = new Oklahoma(this);
		currState.setInitialDifficulty();
		currState = new Kansas(this);
		currState.setInitialDifficulty();
		currState = new Nebraska(this);
		currState.setInitialDifficulty();
		currState = new SDakota(this);
		currState.setInitialDifficulty();
		currState = new NDakota(this);
		currState.setInitialDifficulty();

		currState = new Wyoming(this);
		currState.setInitialDifficulty();
		currState = new Wyoming(this);
		currState.setInitialDifficulty();
		currState = new Wyoming(this);
		currState.setInitialDifficulty();
	}

	public int AssociateRichness(Cell cellToAssociate)
	{
		int chance = 3;
		int choice = Random.Range(0,chance);
		if(cellToAssociate.getRichness() == 0)
		{
			if(choice > 0)
			{
				return 0;
			}
			else
			{
				return Random.Range(50,101);
			}
		}
		else
		{
			if(choice > 0)
			{
				return Random.Range(50,101);
			}
			else
			{
				return 0;
			}
		}
	}
}

public class State 
{
	public Map map;
	public Cell[] Zones;
	public int Environment;
	public int Policy;

	public void changeEnvironment()
	{
		foreach(Cell x in Zones)
		{
			x.SetEnvironment(Environment);
		}
	}

	public void changePolicy()
	{
		foreach(Cell x in Zones)
		{
			x.SetPolicy(Policy);
		}
	}

	public void setInitialDifficulty()
	{
		foreach(Cell x in Zones)
		{
			x.SetDifficulty(Environment,Policy);
		}
	}
}

public class California : State
{
	public California(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(17,0),map.getCell(17,1),map.getCell(17,2),map.getCell(16,1),map.getCell(16,2),
			map.getCell(16,0),map.getCell(15,0),map.getCell(15,1),map.getCell(15,2),map.getCell(14,1),map.getCell(14,2),
			map.getCell(14,0),map.getCell(13,1),map.getCell(13,2),map.getCell(13,0),map.getCell(12,0),map.getCell(12,1),
			map.getCell(12,2),map.getCell(12,3),map.getCell(12,4),map.getCell(11,1),map.getCell(11,2),
			map.getCell(11,3),map.getCell(11,4),map.getCell(10,4),map.getCell(10,2),map.getCell(10,3),
			map.getCell(10,5),map.getCell(9,5),map.getCell(9,3),map.getCell(9,4),map.getCell(9,5),map.getCell(8,5),map.getCell(8,4)};
		Environment = 1;
		Policy = 1;
	}
}
public class Washington : State
{
	public Washington(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(20,1),map.getCell(20,2),
			map.getCell(20,3),map.getCell(20,4),map.getCell(20,5),map.getCell(19,1),map.getCell(19,0),
			map.getCell(19,2),map.getCell(19,3),map.getCell(19,4),map.getCell(19,5),map.getCell(18,1),
			map.getCell(18,2),map.getCell(18,3),map.getCell(18,4),map.getCell(18,5),map.getCell(18,0),map.getCell(17,5),
			map.getCell(17,3),map.getCell(17,4),map.getCell(17,5)};
		Environment = 2;
		Policy = 2;
	}
}
public class Oregon : State
{
	public Oregon(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(21,3),map.getCell(21,4),map.getCell(21,5),map.getCell(21,2),map.getCell(21,1),
			map.getCell(22,3),map.getCell(22,2),map.getCell(22,4),map.getCell(22,5),
			map.getCell(22,1),map.getCell(23,3),map.getCell(23,4),map.getCell(23,5),
			map.getCell(23,1)};
		Environment = 3;
		Policy = 3;
	}
}
public class Nevada : State
{
	public Nevada(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(12,4),map.getCell(12,5),map.getCell(12,6),map.getCell(13,3),
			map.getCell(13,4),map.getCell(13,5),map.getCell(13,6),map.getCell(11,6),map.getCell(11,5),
			map.getCell(14,3),map.getCell(14,4),map.getCell(14,5),map.getCell(14,6),map.getCell(15,3),
			map.getCell(15,4),map.getCell(15,5),map.getCell(15,6),map.getCell(16,3),map.getCell(16,4),
			map.getCell(16,5),map.getCell(16,6)};
		Environment = 4;
		Policy = 4;
	}
}
public class Arizona : State
{
	public Arizona(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(6,10),map.getCell(7,7),map.getCell(11,9),map.getCell(11,10),
			map.getCell(7,8),map.getCell(7,9),map.getCell(7,10),map.getCell(8,6),map.getCell(8,7),
			map.getCell(8,8),map.getCell(8,9),map.getCell(8,10),map.getCell(9,6),map.getCell(9,7),
			map.getCell(9,8),map.getCell(9,9),map.getCell(9,10),map.getCell(10,6),map.getCell(10,7),
			map.getCell(10,8),map.getCell(10,9),map.getCell(10,10),map.getCell(11,7),map.getCell(11,8)};
		Environment = 5;
		Policy = 5;
	}
}
public class Utah : State
{
	public Utah(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(12,8),map.getCell(12,9),map.getCell(12,7),map.getCell(12,10),
			map.getCell(13,8),map.getCell(13,9),map.getCell(13,10),map.getCell(13,7),map.getCell(14,7),
			map.getCell(14,8),map.getCell(14,9),map.getCell(14,10),map.getCell(15,7),map.getCell(15,8),
			map.getCell(16,8),map.getCell(15,9),map.getCell(16,7),map.getCell(16,9)};
		Environment = 6;
		Policy = 6;
	}
}
public class Idaho : State
{
	public Idaho(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(17,6),map.getCell(17,7),map.getCell(17,8),map.getCell(17,9),
			map.getCell(18,6),map.getCell(18,7),map.getCell(18,8),map.getCell(18,9),map.getCell(19,7),
			map.getCell(19,8),map.getCell(19,6),map.getCell(20,6),map.getCell(20,8),map.getCell(20,7),
			map.getCell(21,6),map.getCell(21,7),map.getCell(22,6),map.getCell(23,6)};
		Environment = 7;
		Policy = 7;
	}
}
public class Montana : State
{
	public Montana(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(23,7),map.getCell(23,8),map.getCell(23,9),map.getCell(23,10),
			map.getCell(23,11),map.getCell(23,12),map.getCell(22,10),map.getCell(22,11),map.getCell(22,7),
			map.getCell(22,8),map.getCell(22,9),map.getCell(22,12),map.getCell(22,13),map.getCell(22,14),
			map.getCell(21,8),map.getCell(21,9),map.getCell(21,10),map.getCell(21,11),map.getCell(21,12),
			map.getCell(21,13),map.getCell(21,14),map.getCell(20,10),map.getCell(20,9),map.getCell(20,11),
			map.getCell(20,14),map.getCell(20,12),map.getCell(20,13),map.getCell(19,9),map.getCell(19,10),map.getCell(19,11),
			map.getCell(19,12),map.getCell(19,13),map.getCell(19,14)};
		Environment = 8;
		Policy = 8;
	}
}
public class Wyoming : State
{
	public Wyoming(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(18,10),map.getCell(18,11),map.getCell(18,12),map.getCell(18,13),
			map.getCell(18,14),map.getCell(17,12),map.getCell(17,10),map.getCell(17,11),map.getCell(17,13),
			map.getCell(17,14),map.getCell(16,10),map.getCell(16,11),map.getCell(16,12),map.getCell(16,14),
			map.getCell(16,13),map.getCell(15,10),map.getCell(15,14),map.getCell(15,11),map.getCell(15,12),
			map.getCell(15,13)};
		Environment = 9;
		Policy = 9;
	}
}
public class Colorado : State
{
	public Colorado(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,11),map.getCell(14,12),map.getCell(14,13),map.getCell(14,14),
			map.getCell(14,15),map.getCell(13,11),map.getCell(13,12),map.getCell(13,13),map.getCell(13,14),
			map.getCell(13,15),map.getCell(12,11),map.getCell(12,12),map.getCell(12,13),map.getCell(12,14),
			map.getCell(12,15)};
		Environment = 10;
		Policy = 10;
	}
}
public class NewMexico : State
{
	public NewMexico(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(11,11),map.getCell(11,12),map.getCell(11,13),map.getCell(11,14),
			map.getCell(10,11),map.getCell(10,12),map.getCell(10,13),map.getCell(10,14),map.getCell(9,11),
			map.getCell(9,12),map.getCell(9,13),map.getCell(9,14),map.getCell(8,13),map.getCell(8,14),
			map.getCell(8,11),map.getCell(8,12),map.getCell(7,11),map.getCell(7,12),map.getCell(7,13),map.getCell(7,14),map.getCell(6,11)};
		Environment = 11;
		Policy = 11;
	}
}
public class Texas : State
{
	public Texas(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(2,18),map.getCell(2,19),map.getCell(3,17),map.getCell(3,18),
			map.getCell(3,19),map.getCell(3,20),map.getCell(4,14),map.getCell(4,15),map.getCell(4,16),
			map.getCell(4,17),map.getCell(4,18),map.getCell(4,19),map.getCell(4,20),map.getCell(4,21),
			map.getCell(5,13),map.getCell(5,14),map.getCell(5,15),map.getCell(5,16),map.getCell(5,17),
			map.getCell(5,18),map.getCell(5,19),map.getCell(5,20),map.getCell(5,21),map.getCell(6,12),
			map.getCell(6,13),map.getCell(6,14),map.getCell(6,15),map.getCell(6,16),map.getCell(6,17),map.getCell(6,18),
			map.getCell(6,19),map.getCell(6,20),map.getCell(6,21),map.getCell(7,15),map.getCell(7,16),map.getCell(7,17),
			map.getCell(7,18),map.getCell(7,19),map.getCell(7,21),map.getCell(7,20),map.getCell(8,15),map.getCell(8,16),
			map.getCell(8,17),map.getCell(8,18),map.getCell(9,15),map.getCell(9,16)};
		Environment = 12;
		Policy = 12;
	}
}
public class Oklahoma : State
{
	public Oklahoma(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(11,15),map.getCell(11,16),map.getCell(11,17),map.getCell(11,18),
			map.getCell(11,19),map.getCell(11,20),map.getCell(10,15),map.getCell(10,16),map.getCell(10,17),
			map.getCell(10,18),map.getCell(10,19),map.getCell(10,20),map.getCell(10,21),map.getCell(9,17),
			map.getCell(9,18),map.getCell(9,19),map.getCell(9,20),map.getCell(9,21),map.getCell(8,19),
			map.getCell(8,20),map.getCell(8,21)};
		Environment = 13;
		Policy = 13;
	}
}
public class Kansas : State
{
	public Kansas(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(12,16),map.getCell(12,17),map.getCell(12,18),map.getCell(12,19),
			map.getCell(12,20),map.getCell(13,16),map.getCell(13,17),map.getCell(13,18),map.getCell(13,19),
			map.getCell(13,20),map.getCell(14,16),map.getCell(14,17),map.getCell(14,18),map.getCell(14,19)};
		Environment = 14;
		Policy = 14;
	}
}
public class Nebraska : State
{
	public Nebraska(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(15,15),map.getCell(15,16),map.getCell(15,17),map.getCell(15,18),
			map.getCell(15,19),map.getCell(16,15),map.getCell(16,16),map.getCell(16,17),map.getCell(16,18),
			map.getCell(16,19)};
		Environment = 15;
		Policy = 15;
	}
}
public class SDakota : State
{
	public SDakota(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(17,15),map.getCell(17,16),map.getCell(17,17),map.getCell(17,18),
			map.getCell(17,19),map.getCell(18,15),map.getCell(18,16),map.getCell(18,17),map.getCell(18,18),
			map.getCell(18,19),map.getCell(19,15),map.getCell(19,16),map.getCell(19,17),map.getCell(19,18),
			map.getCell(19,19)};
		Environment = 16;
		Policy = 16;
	}
}
public class NDakota : State
{
	public NDakota(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(20,15),map.getCell(20,16),map.getCell(20,17),map.getCell(20,18),
			map.getCell(20,19),map.getCell(21,15),map.getCell(21,16),map.getCell(21,17),map.getCell(21,18),
			map.getCell(21,19),map.getCell(22,15),map.getCell(22,16),map.getCell(22,17),map.getCell(22,18),
			map.getCell(22,19)};
		Environment = 17;
		Policy = 17;
	}
}
public class Lousiana : State
{
	public Lousiana(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(4,23),map.getCell(4,24),map.getCell(4,25),map.getCell(5,22),
			map.getCell(5,23),map.getCell(5,24),map.getCell(5,25),map.getCell(6,22),map.getCell(6,23),
			map.getCell(7,22),map.getCell(7,23),map.getCell(7,24),
			map.getCell(6,24)};
		Environment = 18;
		Policy = 18;
	}
}
public class Arkansas : State
{
	public Arkansas(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(8,22),map.getCell(8,23),map.getCell(9,22),map.getCell(9,23),
			map.getCell(10,22),map.getCell(10,23)};
		Environment = 19;
		Policy = 19;
	}
}
public class Mississippi : State
{
	public Mississippi(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(6,25),map.getCell(7,24),map.getCell(7,25),map.getCell(8,24),
			map.getCell(8,25),map.getCell(9,24),map.getCell(9,25)};
		Environment = 20;
		Policy = 20;
	}
}
public class Missouri : State
{
	public Missouri(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(11,21),map.getCell(11,22),map.getCell(11,23),map.getCell(12,21),
			map.getCell(12,22),map.getCell(12,23),map.getCell(13,21),map.getCell(13,22),map.getCell(13,23)};
		Environment = 21;
		Policy = 21;
	}
}
public class Iowa : State
{
	public Iowa(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,20),map.getCell(14,21),map.getCell(14,22),map.getCell(15,20),
			map.getCell(15,21),map.getCell(15,22),map.getCell(16,20),map.getCell(16,21),map.getCell(16,22)};
		Environment = 22;
		Policy = 22;
	}
}
public class Minnesota : State
{
	public Minnesota(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(17,20),map.getCell(17,21),map.getCell(17,22),map.getCell(18,20),
			map.getCell(18,21),map.getCell(19,20),map.getCell(19,21),map.getCell(20,21),map.getCell(20,20),
			map.getCell(21,20),map.getCell(21,21),map.getCell(21,22),map.getCell(22,20)};
		Environment = 23;
		Policy = 23;
	}
}
public class Alabama : State
{
	public Alabama(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(6,26),map.getCell(7,26),map.getCell(7,27),map.getCell(8,27),
			map.getCell(8,26),map.getCell(9,26),map.getCell(9,27)};
		Environment = 24;
		Policy = 24;
	}
}
public class Tennessee : State
{
	public Tennessee(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(10,24),map.getCell(10,25),map.getCell(10,26),map.getCell(10,27),
			map.getCell(10,28),map.getCell(10,29),map.getCell(11,24),map.getCell(11,25),map.getCell(11,26),map.getCell(10,27),
			map.getCell(11,28),map.getCell(11,29)};
		Environment = 25;
		Policy = 25;
	}
}
public class Kentucky : State
{
	public Kentucky(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(12,26),map.getCell(12,27),map.getCell(12,28),map.getCell(12,29),
			map.getCell(13,26),map.getCell(13,27),map.getCell(13,28),map.getCell(13,29)};
		Environment = 26;
		Policy = 26;
	}
}
public class Illinois : State
{
	public Illinois(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(12,24),map.getCell(12,25),map.getCell(13,24),map.getCell(13,25),
			map.getCell(14,23),map.getCell(14,25),map.getCell(14,24),map.getCell(15,24),map.getCell(15,23),
			map.getCell(15,25),map.getCell(16,23),map.getCell(16,24)};
		Environment = 27;
		Policy = 27;
	}
}
public class Indiana : State
{
	public Indiana(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,26),map.getCell(14,27),map.getCell(15,26),map.getCell(15,27)};
		Environment = 28;
		Policy = 28;
	}
}
public class Wisconsin : State
{
	public Wisconsin(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(17,23),map.getCell(17,24),map.getCell(18,23),map.getCell(18,22),
			map.getCell(18,24),map.getCell(19,22),map.getCell(19,23),map.getCell(19,24),map.getCell(20,23),
			map.getCell(20,22)};
		Environment = 29;
		Policy = 29;
	}
}
public class Michigan : State
{
	public Michigan(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(20,24),map.getCell(20,25),map.getCell(16,26),map.getCell(16,27),
			map.getCell(17,26),map.getCell(17,27),map.getCell(17,28),map.getCell(18,26),map.getCell(18,27),
			map.getCell(18,28),map.getCell(19,27)};
		Environment = 30;
		Policy = 30;
	}
}
//Stopped Here//
public class Florida : State
{
	public Florida(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(2,32),map.getCell(2,33),map.getCell(3,31),map.getCell(3,32),
			map.getCell(3,33),map.getCell(4,31),map.getCell(4,32),map.getCell(5,29),map.getCell(5,30),
			map.getCell(5,31),map.getCell(5,32),map.getCell(6,27),map.getCell(6,28),map.getCell(6,29),
			map.getCell(6,30),map.getCell(6,31)};
		Environment = 31;
		Policy = 31;
	}
}
public class Georgia : State
{
	public Georgia(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(7,28),map.getCell(7,29),map.getCell(7,30),map.getCell(7,31),
			map.getCell(8,28),map.getCell(8,29),map.getCell(8,30),map.getCell(8,31),map.getCell(9,28),
			map.getCell(9,29),map.getCell(9,30)};
		Environment = 32;
		Policy = 32;
	}
}
public class SCarolina : State
{
	public SCarolina(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(9,31),map.getCell(9,32),map.getCell(10,30),map.getCell(10,31),
			map.getCell(10,32)};
		Environment = 33;
		Policy = 33;
	}
}
public class NCarolina : State
{
	public NCarolina(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(11,30),map.getCell(11,31),map.getCell(11,32),map.getCell(11,33),
			map.getCell(12,30),map.getCell(12,31),map.getCell(12,32),map.getCell(12,33)};
		Environment = 34;
		Policy = 34;
	}
}
public class Virgina : State
{
	public Virgina(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(13,30),map.getCell(13,31),map.getCell(13,32),map.getCell(13,33)};
		Environment = 35;
		Policy = 35;
	}
}
public class WVirgina : State
{
	public WVirgina(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,30),map.getCell(14,31)};
		Environment = 36;
		Policy = 36;
	}
}
public class Ohio : State
{
	public Ohio(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,28),map.getCell(14,29),map.getCell(15,28),map.getCell(15,29),
			map.getCell(15,30),map.getCell(16,30)};
		Environment = 37;
		Policy = 37;
	}
}
public class Maryland : State
{
	public Maryland(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,32),map.getCell(14,33),map.getCell(13,34)};
		Environment = 38;
		Policy = 38;
	}
}
public class Delaware : State
{
	public Delaware(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(14,34)};
		Environment = 39;
		Policy = 39;
	}
}
public class Pennsylvania : State
{
	public Pennsylvania(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(15,31),map.getCell(15,32),map.getCell(15,33),map.getCell(16,31),
			map.getCell(16,32),map.getCell(16,33)};
		Environment = 40;
		Policy = 40;
	}
}
public class NewJersey : State
{
	public NewJersey(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(15,34),map.getCell(16,34)};
		Environment = 41;
		Policy = 41;
	}
}
public class NewYork : State
{
	public NewYork(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(17,30),map.getCell(17,31),map.getCell(17,32),map.getCell(17,33),
			map.getCell(17,34),map.getCell(18,31),map.getCell(18,32),map.getCell(18,33),map.getCell(19,32),
			map.getCell(19,33),map.getCell(20,33)};
		Environment = 42;
		Policy = 42;
	}
}
public class Connecticut : State
{
	public Connecticut(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(18,34)};
		Environment = 43;
		Policy = 43;
	}
}
public class RhodeIsland : State
{
	public RhodeIsland(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(18,35)};
		Environment = 44;
		Policy = 44;
	}
}
public class Massachusetts : State
{
	public Massachusetts(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(18,36),map.getCell(19,34),map.getCell(19,35),map.getCell(19,36)};
		Environment = 45;
		Policy = 45;
	}
}
public class Vermont : State
{
	public Vermont(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(20,34),map.getCell(21,34)};
		Environment = 46;
		Policy = 46;
	}
}
public class NewHampshire : State
{
	public NewHampshire(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(20,35),map.getCell(21,35)};
		Environment = 47;
		Policy = 47;
	}
}
public class Maine : State
{
	public Maine(Map calling)
	{
		map = calling;
		Zones = new Cell[] {map.getCell(20,36),map.getCell(21,36),map.getCell(21,37),map.getCell(21,38),
			map.getCell(22,36),map.getCell(22,37),map.getCell(22,38),map.getCell(23,36),map.getCell(23,37)};
		Environment = 48;
		Policy = 48;
	}
}