using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Will contain event variables and helper functions
 */ 

public class Event : MonoBehaviour
{
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS,
        KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY,
        ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI,
        WY
    };

    public Text eventDescription;
    public State state;
    public Option[] options;
    
    
    //Might use this variable if number of options is not constant
    //public int numOptions;
    	
}

public class Option : MonoBehaviour
{
    public enum optionType { immediate, delayed };

    public optionType type;
    public Text optionDescription;
    public int requirement;
}
