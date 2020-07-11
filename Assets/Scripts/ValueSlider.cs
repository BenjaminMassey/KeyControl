using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSlider : MonoBehaviour
{
    Text text_obj;
    Slider slider_obj;

    // Start is called before the first frame update
    void Start()
    {
        int cc = transform.childCount;
        for (int i = 0; i < cc; i++)
        {
            Transform t = transform.GetChild(i);
            GameObject go = t.gameObject;
            if (go.name.Contains("Text"))
            {
                text_obj = go.GetComponent<Text>();
            }
            if (go.name.Contains("Slider"))
            {
                slider_obj = go.GetComponent<Slider>();
            }
        }
        if (name.Equals("Taxes"))
        {
            slider_obj.value = MainValues.tax_rate;
            text_obj.text = GlobalText.GetNicePercent(MainValues.tax_rate);
        }
        if (name.Equals("Education"))
        {
            slider_obj.maxValue = MainValues.money;
            slider_obj.value = MainValues.education;
            text_obj.text = MainValues.education.ToString();
        }
        if (name.Equals("Military"))
        {
            slider_obj.maxValue = MainValues.money;
            slider_obj.value = MainValues.military;
            text_obj.text = MainValues.military.ToString();
        }
        if (name.Equals("GovernmentSalaries"))
        {
            slider_obj.maxValue = MainValues.money;
            slider_obj.value = MainValues.government_salaries;
            text_obj.text = MainValues.government_salaries.ToString();
        }
    }
    
    void FixedUpdate()
    {
        if (name.Equals("Taxes"))
        {
            MainValues.tax_rate = slider_obj.value;
            text_obj.text = GlobalText.GetNicePercent(MainValues.tax_rate) + "%";
        }
        if (name.Equals("Education") || name.Equals("Military")
            || name.Equals("GovernmentSalaries"))
        {
            slider_obj.maxValue = MainValues.money;
            slider_obj.value = Mathf.Round(slider_obj.value);
            text_obj.text = slider_obj.value.ToString();
            if (name.Equals("Education"))
            {
                MainValues.education = slider_obj.value;
            }
            if (name.Equals("Military"))
            {
                MainValues.military = slider_obj.value;
            }
            if (name.Equals("GovernmentSalaries"))
            {
                MainValues.government_salaries = slider_obj.value;
            }
        }
    }
}
