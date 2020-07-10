using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    Text text_obj;
    // Start is called before the first frame update
    void Start()
    {
        text_obj = GetComponent<Text>();
        GlobalText.text = "Citizen: ";
        GlobalText.text += GlobalText.GetNicePercent(MainValues.GetCitizenPercent()) + "%";
        GlobalText.text += " | ";
        GlobalText.text += "Government: ";
        GlobalText.text += GlobalText.GetNicePercent(MainValues.GetGovernmentPercent()) + "%";
    }

    void FixedUpdate()
    {
        text_obj.text = GlobalText.text;
    }
}

public static class GlobalText
{
    public static string text;

    public static string GetNicePercent(float percent)
    {
        return (Mathf.Round(percent * 1000.0f) / 10.0f).ToString();
    }
}