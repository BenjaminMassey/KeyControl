using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFuctions : MonoBehaviour
{
    public bool running;

    private Text time_text;

    private int day;
    private int year;

    private float secondsPerDay = 0.3f;

    private void Start()
    {
        time_text = GameObject.Find("TimeText").GetComponent<Text>();
        time_text.text = "Year 0\nDay 0";
        running = true;
        StartCoroutine("RunTime");
    }

    IEnumerator RunTime()
    {
        day = 0;
        year = 0;
        while (true)
        {
            if (running)
            {
                for (int i = 0; i < 50 * secondsPerDay; i++)
                {
                    yield return new WaitForFixedUpdate();
                }
                day++;
                if ((day % 7) == 0)
                {
                    MainValues.Week();
                }
                if (day == 365)
                {
                    day = 0;
                    year += 1;
                    MainValues.Year();
                }
                MainValues.Day();
                TextUpdate();
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }

    private void TextUpdate()
    {
        time_text.text = "Year " + year + "\n Day " + day;
    }


}
