using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void REEEEE()
    {
        MainValues.money = 10000.0f; // in $
        MainValues.citizen_wealth = 500.0f; // in $
        MainValues.government_wealth = 1500.0f; // in $
        MainValues.tax_rate = 0.1f; // in %
        MainValues.education = 100.0f; // in $
        MainValues.military = 300.0f; // in $
        MainValues.outside_agitation = 0.2f; // reach 1.0f and war
        MainValues.government_salaries = 200.0f; // in $

        SceneManager.LoadScene("Main");
        
    }
}
