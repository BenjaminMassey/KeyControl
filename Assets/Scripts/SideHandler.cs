using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideHandler : MonoBehaviour
{
    public AudioSource left_sfx;
    public AudioSource right_sfx;

    private GameObject left_side;
    private GameObject right_side;

    // Start is called before the first frame update
    private void Start()
    {
        left_side = GameObject.Find("LeftSide");
        right_side = GameObject.Find("RightSide");
        MainValues.onRightSide = false;
        ShowHideSide();
    }

    private void ShowHideSide()
    {
        left_side.SetActive(!MainValues.onRightSide);
        GameObject.Find("STUPIDLEFTARROW").GetComponent<Text>().enabled = MainValues.onRightSide;
        right_side.SetActive(MainValues.onRightSide);

        if (MainValues.onRightSide) { right_sfx.Play(); }
        else { left_sfx.Play(); }
    }

    public void ToggleSide()
    {
        StartCoroutine("SideChange");
    }

    private IEnumerator SideChange()
    {
        left_sfx.Stop();
        right_sfx.Stop();

        left_side.SetActive(false);
        GameObject.Find("STUPIDLEFTARROW").GetComponent<Text>().enabled = false;
        right_side.SetActive(false);

        GameObject p = transform.parent.gameObject;
        Vector3 pos = p.transform.position;
        float amount = 0.06f;
        float a = 0.0f;
        float b = 15.25f;
        float t;
        if (MainValues.onRightSide) { t = 1.0f; }
        else { t = 0.0f; }
        while (true)
        {
            if (MainValues.onRightSide) { t -= amount; }
            else { t += amount; }
            float loc = (1.0f - t) * a + b * t;
            if (t >= 1.0f || t <= 0.0f ) { break; }
            p.transform.position = new Vector3(loc, pos.y, pos.z);
            yield return new WaitForFixedUpdate();
        }
        
        MainValues.onRightSide = !MainValues.onRightSide;
        ShowHideSide();
    }
}
