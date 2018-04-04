using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;


/*
 * Will contain event variables and helper functions
 */ 

public class Event
{
    public string eventDescription;
    public Option[] options = new Option[3];

    public Event(string eventDesc)
    {
        eventDescription = eventDesc;
    }
}

public class Option
{
    public string optionDescription;
    public int prEffect;
    public int legalEffect;
    public int researchEffect;
    public double moneyPercentChange;
    public int prReq;
    public int legalReq;
    public int researchReq;
    public int doomCounter;
    public double chance;
    public int marketEffect;
    public int regulation;
    public string link;

    public Option(string od, int pre, int le, int re, double mpc,
                   int prr, int lr, int rr, int dc, double c, int me, int r, string l)
    {
        optionDescription = od;
        prEffect = pre;
        legalEffect = le;
        researchEffect = re;
        moneyPercentChange = mpc;
        prReq = prr;
        legalReq = lr;
        researchReq = rr;
        doomCounter = dc;
        chance = c;
        marketEffect = me;
        regulation = r;
        link = l;
    }
}
