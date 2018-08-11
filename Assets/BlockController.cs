using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public float delay = 1f;
    public int hp = 10;


    float elapsed = 0f;
    

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (hp <= 0)
            Destroy(this.gameObject);
        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            hp--;
        }
    }
}
