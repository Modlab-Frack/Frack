using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour {

    public Image healthbar;

    public float statsValue = 0;

	// Update is called once per frame
	void Update () {
        statsChange(statsValue);
	}

    void statsChange(float statsValue)
    {
        float amount = (statsValue / 50.0f) * 180.0f / 360;
        healthbar.fillAmount = amount;
    }
}

