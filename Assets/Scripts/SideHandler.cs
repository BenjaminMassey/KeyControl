using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideHandler : MonoBehaviour
{
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
        right_side.SetActive(MainValues.onRightSide);
    }

    public void ToggleSide()
    {
        GameObject p = transform.parent.gameObject;
        Vector3 pos = p.transform.position;
        if (MainValues.onRightSide)
        {
            p.transform.position = new Vector3(0.0f, pos.y, pos.z);
        }
        else
        {
            p.transform.position = new Vector3(17.25f, pos.y, pos.z);
        }

        MainValues.onRightSide = !MainValues.onRightSide;
        
        ShowHideSide();
    }
}
