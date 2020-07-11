using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTornado : MonoBehaviour
{
    public GameObject[] tornadoes;

    public float seconds = 3.0f;
    public float chance = 0.05f;

    private bool doing;

    // Start is called before the first frame update
    void Start()
    {
        doing = false;
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        while (true)
        {
            for (int i = 0; i < 50 * seconds; i++)
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
        MainValues.money = 0.5f * MainValues.money;
        doing = false;
    }
}
