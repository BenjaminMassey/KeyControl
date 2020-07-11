﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    
    public GameObject money_text_obj;
    public GameObject citizen_text_obj;
    public GameObject gov_text_obj;

    Text main_text = null;
    Text money_text = null;
    Text citizen_text = null;
    Text gov_text = null;

    // Start is called before the first frame update
    void Start()
    {
        main_text = GetComponent<Text>();
        money_text = GameObject.Find("MoneyText").GetComponent<Text>();
        citizen_text = citizen_text_obj.GetComponent<Text>();
        gov_text = gov_text_obj.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        main_text.text = "Outside Threat Chance: ";
        main_text.text += GlobalText.GetNicePercent(MainValues.GetOutsideAgitation()) + "%";

        money_text.text = "$" + MainValues.money;

        if (!MainValues.onRightSide)
        {
            citizen_text.text = "Citizens\n";
            citizen_text.text += "Wealth: $" + Mathf.Round(MainValues.citizen_wealth) + "\n";
            citizen_text.text += "Happiness: " + GlobalText.GetNicePercent(MainValues.GetCitizenPercent()) + "%";
        }

        if (MainValues.onRightSide)
        {
            gov_text.text = "Government\n";
            gov_text.text += "Wealth: $" + Mathf.Round(MainValues.government_wealth) + "\n";
            gov_text.text += "Happiness: " + GlobalText.GetNicePercent(MainValues.GetGovernmentPercent()) + "%";
        }
    }
}

public static class GlobalText
{
    public static string GetNicePercent(float percent)
    {
        return (Mathf.Round(percent * 1000.0f) / 10.0f).ToString();
    }
}