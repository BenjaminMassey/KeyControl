using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTornado : MonoBehaviour
{
    public GameObject[] tornadoes;
    public AudioSource sfx;

    public float wait_time = 10.0f; // wait [WAIT_TIME] seconds before starting
    public float freq = 3.0f; // tornadoes every [FREQ] seconds
    public float chance = 0.03f; // [CHANCE]% chance each time

    private bool doing;

    // Start is called before the first frame update
    void Start()
    {
        doing = false;
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        for (int i = 0; i < 50 * wait_time; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        while (true)
        {
            for (int i = 0; i < 50 * freq; i++)
            {
                yield return new WaitForFixedUpdate();
            }
            float r = Random.Range(0.0f, 1.0f);
            if (r < chance)
            {
                if (!doing)
                {
                    StartCoroutine("Do");
                }
            }
        }
    }

    IEnumerator Do()
    {
        doing = true;
        sfx.Play();
        float fadeSecs = 1.0f;
        float hangSecs = 1.0f;
        float amount = (255f / (50f * fadeSecs)) / 255f;
        for (int i = 0; i < 50 * fadeSecs; i++)
        {
            for (int j = 0; j < tornadoes.Length; j++)
            {
                Color c = tornadoes[j].GetComponent<SpriteRenderer>().color;
                c.a += amount;
                Debug.Log(c.a);
                tornadoes[j].GetComponent<SpriteRenderer>().color = c;
                tornadoes[j].GetComponent<SpriteRenderer>().UpdateGIMaterials();
            }
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < 50 * hangSecs; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < 50 * fadeSecs; i++)
        {
            for (int j = 0; j < tornadoes.Length; j++)
            {
                Color c = tornadoes[j].GetComponent<SpriteRenderer>().color;
                c.a -= amount;
                Debug.Log(c.a);
                tornadoes[j].GetComponent<SpriteRenderer>().color = c;
            }
            yield return new WaitForFixedUpdate();
        }
        GainLossEffect gle = GameObject.Find("Player").GetComponent<GainLossEffect>();
        gle.Handle(1.0f, 0.9f); // force red money text effect
        gle.loss_sfx.Play(); // force loss sound effect
        MainValues.money = 0.5f * MainValues.money;
        sfx.Stop();
        doing = false;
    }
}
