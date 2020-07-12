using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = "You made it to " + EndData.month +
            " of year " + EndData.year + ".";
    }
}

public static class EndData
{
    public static int year = 0;
    public static string month = "January";
}
