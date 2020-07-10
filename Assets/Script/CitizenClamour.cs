using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenClamour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Clamour");
    }

    // Update is called once per frame
    IEnumerator Clamour()
    {
        Vector2 start = transform.position;
        float bottom = start.y - Random.Range(0.05f, 0.2f);
        float top = start.y + Random.Range(0.05f, 0.2f);

        float amount = 3 / 50.0f;
        bool up = true;
        float t = 0.0f;
        while (true)
        {
            if (up) { t += amount;  }
            else { t -= amount; }
            float loc = (1.0f - t) * bottom + top * t;
            if (t >= 1.0f) { up = false; }
            if (t <= 0.0f) { up = true; }
            transform.position = new Vector2(start.x, loc);
            yield return new WaitForFixedUpdate();
        }
    }
}
