using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class EventMaintenance : MonoBehaviour {
    public List<Event> events = new List<Event>();

	// Use this for initialization
	void Start () {

        // Read in event csv
        using (var reader = new StreamReader(@"C:\test.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');
                string description = values[4];
                Event newEvent = new Event(description);
                events.Add(newEvent);
            }
        }

        using (var reader = new StreamReader(@"C:\test.csv"))
        {
            int count = 0;
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
                string link = values[12];
                string optionDescription = values[13];

                events[eventID].options[count] = new Option(optionDescription, prEffect, legalEffect, researchEffect,
                                                            moneyPercentChange, prReq, legalReq, researchReq, doomCounter,
                                                            chance, marketEffect, regulation, link);

                count = (count + 1) % 3;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
