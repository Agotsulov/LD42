using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public float delay = 1f;
    public int hp = 10;

    public GameObject snow;

    public float dy = 0.3f;
    public float dx = 0.3f;

    public float step = 0.2f;


    float elapsed = 0f;
    

    // Use this for initialization
    void Start()
    {

    }

    void Generate()
    {
        for (float y = this.gameObject.transform.position.x  - dy; y < dy; y += step)
        {
            for (float x = this.gameObject.transform.position.x - dx; x < dx; x += step)
            {
                Vector3 v = new Vector3(x, y, 0);
                Instantiate(snow, v, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Generate();
            Destroy(this.gameObject);
        }
        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            hp--;
        }
    }
}
