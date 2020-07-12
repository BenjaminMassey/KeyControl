using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainValues
{
    // Logic stuff
    public static bool onRightSide;

    // Amounts
    public static float money = 10000.0f; // in $
    public static float citizen_wealth = 500.0f; // in $
    public static float government_wealth = 1500.0f; // in $
    public static float tax_rate = 0.1f; // in %
    public static float education = 100.0f; // in $
    public static float military = 300.0f; // in $
    public static float outside_agitation = 0.2f; // reach 1.0f and war
    public static float government_salaries = 200.0f; // in $
    public static float citizen_smarts = 50.0f;

    // Citizen component multipliers
    private static float citizen_wealth_value = 1.6f;
    private static float tax_rate_value = 50.0f;
    private static float education_value = 0.2f;

    // Government component multipliers
    private static float government_wealth_value = 2.0f;
    private static float military_value = 4.0f;
    private static float outside_agitation_value = 3.0f;
    private static float government_salaries_value = 10.0f;

    // Values for percentages / failure / etc
    private static float citizen_min = 300.0f;
    private static float citizen_max = 4000.0f;
    private static float government_min = 1500.0f;
    private static float government_max = 20000.0f;
    private static float military_base = 400.0f;

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
        float gsv = government_salaries_value;
        return gwv * government_wealth 
                + mv * military 
                + (oav * -1.0f * outside_agitation)
                + gsv * government_salaries;
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

    public static float GetOutsideAgitation()
    {
        return outside_agitation;
    }

    public static string GetNicePercent(float percent)
    {
        return (Mathf.Round(percent * 1000.0f) / 10.0f).ToString();
    }

    public static void Year()
    {
        float money_before = money;

        // Do citizen taxes
        float tax_amount = tax_rate * citizen_wealth;
        money += tax_amount;
        citizen_wealth -= tax_amount;
        citizen_wealth = Mathf.Max(0.0f, citizen_wealth);

        // Educate citizens
        citizen_smarts += education / 5.0f;

        // Give rest of gov money
        government_wealth += government_salaries;
        money -= government_salaries;
        money = Mathf.Max(0.0f, money);

        // Take out spent money
        money -= education + military;
        money = Mathf.Max(0.0f, money);

        // Foreign relations
        outside_agitation += 2f * outside_agitation_value * (((military_base - military) / military_base) / 100.0f);
        outside_agitation = Mathf.Max(0.0f, outside_agitation);
        outside_agitation = Mathf.Min(1.0f, outside_agitation);

        float money_after = money;

        GainLossEffect gle = GameObject.Find("Player").GetComponent<GainLossEffect>();
        gle.Handle(money_before, money_after);
    }

    public static void Month()
    {
        // Common decay
        government_wealth -= Mathf.Max(20.0f, government_wealth * 0.03f);
        if (money < 500.0f || government_wealth < 500.0f || government_salaries == 0.0f)
        {
            government_wealth -= 20.0f;
        }
        government_wealth = Mathf.Max(0.0f, government_wealth);
        citizen_smarts -= citizen_smarts * 0.02f;

        // Common accumulation
        citizen_wealth += 0.005f * citizen_wealth * (citizen_smarts / 50.0f);
        money += 5.0f;
    }
}
