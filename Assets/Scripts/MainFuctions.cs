using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFuctions : MonoBehaviour
{
    public bool running;

    private Text time_text;

    private int month;
    private int year;

    private string[] months = { "January", "February", "March",
                                "April", "May", "June", "July",
                                "August", "September", "October",
                                "November", "December" };

    private float secondsPerMonth = 1.0f;

    private void Start()
    {
        time_text = GameObject.Find("TimeText").GetComponent<Text>();
        time_text.text = "Year 0\nJanuary";
        running = false;
        StartCoroutine("RunTime");
    }

    IEnumerator RunTime()
    {
        month = 0;
        year = 0;
        while (true)
        {
            if (running)
            {
                for (int i = 0; i < 50 * secondsPerMonth; i++)
                {
                    yield return new WaitForFixedUpdate();
                }
                month++;
                if (month == 12)
                {
                    month = 0;
                    year += 1;
                    MainValues.Year();
                }
                MainValues.Month();
                TextUpdate();
                EndData.month = months[month];
                EndData.year = year;
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void TextUpdate()
    {
        time_text.text = "Year " + year + "\n" + months[month];
    }


}
