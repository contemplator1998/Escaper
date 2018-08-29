using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyController : itemLightning {
    
	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
    {
        var player = GameObject.Find("Player");
		if(distance < 2)
		if (col.gameObject.name.Equals("Player") && !player.GetComponent<Controller>().onTryKeyObtain())
        {
			player.GetComponent<Controller>().onKeyObtained();
            GetComponentInChildren<SpriteRenderer>().enabled = false;
			GetComponentInChildren<Collider>().enabled = false;
            GetComponentInChildren<Light>().enabled = false;
        }
    }
}
