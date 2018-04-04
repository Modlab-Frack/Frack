using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class EventMaintenance : MonoBehaviour {
    public List<Event> events = new List<Event>();

	// Use this for initialization
	public EventMaintenance() {

        // Read in event csv
        using (var reader = new StreamReader(@"Assets/Scripts/testOptions.tsv"))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');
                string description = values[4];
                Debug.Log(description);
                Event newEvent = new Event(description);
                events.Add(newEvent);
            }
        }

        using (var reader = new StreamReader(@"Assets/Scripts/testEvents.tsv"))
        {
            int count = 0;
            reader.ReadLine();
            int lineNum = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');
                int eventID = int.Parse(values[0]);
                int prEffect = int.Parse(values[1]);
                int legalEffect = int.Parse(values[2]);
                int researchEffect = int.Parse(values[3]);
                double moneyPercentChange = double.Parse(values[4]);
                int prReq = int.Parse(values[5]);
                int legalReq = int.Parse(values[6]);
                int researchReq = int.Parse(values[7]);
                int doomCounter = int.Parse(values[8]);
                double chance = double.Parse(values[9]);
                int marketEffect = int.Parse(values[10]);
                int regulation = int.Parse(values[11]);
                string optionDescription = values[12];
                Debug.Log(optionDescription);
                Debug.Log(count);

                events[eventID - 1].options[count] = new Option(optionDescription, prEffect, legalEffect, researchEffect,
                                                            moneyPercentChange, prReq, legalReq, researchReq, doomCounter,
                                                            chance, marketEffect, regulation, optionDescription);
                
                lineNum = lineNum + 1;
                count = (count + 1) % 3;
           } 
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
