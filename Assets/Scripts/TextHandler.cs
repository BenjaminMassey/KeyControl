using System.Collections;
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
        main_text.text = GlobalText.text;

        money_text.text = "$" + GlobalText.GetNiceMoney(MainValues.money);

        if (!MainValues.onRightSide)
        {
            citizen_text.text = "Citizens\n";
            citizen_text.text += "Wealth: $" + GlobalText.GetNiceMoney(MainValues.citizen_wealth) + "\n";
            citizen_text.text += "Happiness: " + GlobalText.GetNicePercent(MainValues.GetCitizenPercent()) + "%\n";
            citizen_text.text += "Smarts: " + Mathf.Round(MainValues.citizen_smarts);
        }

        if (MainValues.onRightSide)
        {
            gov_text.text = "Government\n";
            gov_text.text += "Wealth: $" + GlobalText.GetNiceMoney(MainValues.government_wealth) + "\n";
            gov_text.text += "Happiness: " + GlobalText.GetNicePercent(MainValues.GetGovernmentPercent()) + "%\n";
            gov_text.text += "Foreign Threat: ";
            gov_text.text += GlobalText.GetNicePercent(MainValues.GetOutsideAgitation()) + "%";
        }
    }
}

public static class GlobalText
{
    public static string text= "";

    public static string GetNiceMoney(float money)
    {
        string m = money.ToString();
        string[] ms = m.Split('.');
        string nm = ms[0] + ".";
        if (ms.Length > 1)
        {
            string n = "";
            if (ms[1].Length > 2)
            {
                n += ms[1][0];
                n += ms[1][1];
            }
            else
            {
                n += ms[1];
                if (n.Length == 1)
                {
                    n += "0";
                }
            }
            nm += n;
        }
        else
        {
            nm += "00";
        }
        return nm;
    }
    public static string GetNicePercent(float percent)
    {
        return (Mathf.Round(percent * 1000.0f) / 10.0f).ToString();
    }
}