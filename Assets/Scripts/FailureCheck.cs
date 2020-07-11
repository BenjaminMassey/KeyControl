using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureCheck : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (MainValues.outside_agitation == 1.0f)
        {
            SceneManager.LoadScene("ForeignFail");
        }
        if (MainValues.GetCitizenPercent() == 0.0f)
        {
            SceneManager.LoadScene("CitizenFail");
        }
        if (MainValues.GetGovernmentPercent() == 0.0f)
        {
            SceneManager.LoadScene("GovFail");
        }
    }
}
