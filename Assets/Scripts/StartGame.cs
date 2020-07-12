using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private GameObject left_side;
    // Start is called before the first frame update
    private void Start()
    {
        /*
        GameObject.Find("STUPIDLEFTARROW").SetActive(false);
        left_side = GameObject.Find("LeftSide");
        left_side.SetActive(false);
        GameObject.Find("RightSide").SetActive(false);
        */
    }
    public void Begin()
    {
        //left_side.SetActive(true);
        GameObject.Find("Canvas").GetComponent<MainFuctions>().running = true;
        Destroy(gameObject);
    }
}
