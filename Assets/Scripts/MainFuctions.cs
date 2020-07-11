using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFuctions : MonoBehaviour
{
    private Text year_text;

    private void Start()
    {
        year_text = GameObject.Find("YearText").GetComponent<Text>();
        year_text.text = "Year 0";
    }

    // For button
    public void PerformYear()
    {
        MainValues.DoAYear();
        year_text.text = "Year " + MainValues.year;
    }
}
