using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainValues
{
    // Amounts
    public static float money = 10000.0f; // in $
    public static float debt = 0.0f; // in $
    public static float citizen_wealth = 500.0f; // in $
    public static float government_wealth = 1500.0f; // in $
    public static float tax_rate = 0.2f; // in %
    public static float education = 400.0f; // in $
    public static float military = 800.0f; // in $
    public static float outside_agitation = 0.2f; // reach 1.0f and war
    public static float government_kickbacks = 800.0f; // in $

    // Citizen component multipliers
    private static float citizen_wealth_value = 1.0f;
    private static float tax_rate_value = 50.0f;
    private static float education_value = 1.0f;

    // Government component multipliers
    private static float government_wealth_value = 1.0f;
    private static float military_value = 3.0f;
    private static float outside_agitation_value = 2.0f;
    private static float government_kickbacks_value = 3.0f;

    // Values for percentages / failure / etc
    private static float citizen_min = 100.0f;
    private static float citizen_max = 2000.0f;
    private static float government_min = 1000.0f;
    private static float government_max = 20000.0f;

    private static float GetCitizenHappiness()
    {
        float cwv = citizen_wealth_value;
        float trv = tax_rate_value;
        float ev = education_value;
        return cwv * citizen_wealth
                + (trv * -1.0f * tax_rate)
                + ev * education;
    }

    private static float GetGovernmentHappiness()
    {
        float gwv = government_wealth_value;
        float mv = military_value;
        float oav = outside_agitation_value;
        float gkv = government_kickbacks_value;
        return gwv * government_wealth 
                + mv * military 
                + (oav * -1.0f * outside_agitation)
                + gkv * government_kickbacks;
    }

    public static float GetCitizenPercent()
    {
        float val = (GetCitizenHappiness() - citizen_min) / citizen_max;
        val = Mathf.Min(val, 1.0f);
        val = Mathf.Max(0.0f, val);
        return val;
    }

    public static float GetGovernmentPercent()
    {
        float val = (GetGovernmentHappiness() - government_min) / government_max;
        val = Mathf.Min(val, 1.0f);
        val = Mathf.Max(0.0f, val);
        return val;
    }

    public static string GetNicePercent(float percent)
    {
        return (Mathf.Round(percent * 1000.0f) / 10.0f).ToString();
    }
}
