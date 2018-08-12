﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerController.score += 10;
            collision.gameObject.GetComponent<HP>().hp--;
            Destroy(this.gameObject);
        }    
    }
}
