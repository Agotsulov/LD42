using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject gameObject;
    public float delay = 1f;

    public float dy = 5f;
    public float dx = 8f;

    public float step = 0.1f;

    float elapsed = 0f;


    void Start()
    {
        for (float y = -dy; y < dy; y += step)
        {
            for (float x = -dx; x < dx; x += step)
            {
                Vector3 v = new Vector3(x, y, 0);
                Instantiate(gameObject, v, Quaternion.identity);
            }
        }
    }

    
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            Generate();
        }
    }

    public void Generate(){
        Vector3 v = new Vector3(Random.Range(-10.75f, 10.75f), Random.Range(-5f, 5f), 0);
        GameObject o = Instantiate(gameObject, v, Quaternion.identity);
        
    }
}
