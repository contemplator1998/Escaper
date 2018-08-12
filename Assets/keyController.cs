using System.Collections;
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
        if (col.gameObject.name.Equals("Player"))
        {
            var player = GameObject.Find("Player");
            player.GetComponent<gameController>().onKeyObtained();
            Destroy(gameObject);
        }
    }
}
