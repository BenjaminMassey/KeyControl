using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCitizens : MonoBehaviour
{
    public Sprite citizen_base;

    private int numCitizens;

    private GameObject[] citizens;

    // Start is called before the first frame update
    void Start()
    {
        numCitizens = 25;

        for (int i = 0; i < numCitizens; i++)
        {
            Vector2 spawn = new Vector2();
            spawn.x = transform.position.x + Random.Range(-8.0f, 8.0f);
            spawn.y = transform.position.y + Random.Range(-0.5f, 0.5f);
            GameObject go = new GameObject();
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<SpriteRenderer>().sprite = citizen_base;
            go.transform.position = spawn;
            go.transform.rotation = Quaternion.identity;
            go.AddComponent<CitizenClamour>();
            go.transform.parent = transform;
        }
    }
}
