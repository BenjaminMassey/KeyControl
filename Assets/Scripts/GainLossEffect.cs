using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainLossEffect : MonoBehaviour
{
    public GameObject money_text_go;

    public AudioSource gain_sfx;
    public AudioSource loss_sfx;

    private float flash_time = 1.0f; // seconds
    private Text money_text_obj;
    private Color c;

    // Start is called before the first frame update
    void Start()
    {
        money_text_obj = money_text_go.GetComponent<Text>();
    }

    public void Handle(float before, float after)
    {
        bool loss;
        if (after - before > 0.0f) { loss = false; }
        else { loss = true; }

        if (loss)
        {
            loss_sfx.Play();
            c = new Color(1.0f, 0.0f, 0.0f);
        }
        else
        {
            gain_sfx.Play();
            c = new Color(0.0f, 1.0f, 0.0f);
        }
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        Color orig = new Color(0.0f, 0.0f, 0.0f); // force black cuz reasons
        money_text_obj.color = c;
        for (int i = 0; i < 50 * flash_time; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        money_text_obj.color = orig;
    }
}
