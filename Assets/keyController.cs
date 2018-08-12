﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
    {
        var player = GameObject.Find("Player");
        if (col.gameObject.name.Equals("Player") && !player.GetComponent<gameController>().onTryKeyObtain())
        {
            player.GetComponent<gameController>().onKeyObtained();
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponentInChildren<Light>().enabled = false;
        }
    }
}
