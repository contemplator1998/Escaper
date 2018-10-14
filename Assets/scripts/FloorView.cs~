using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorView : MonoBehaviour {
	public GameObject TWOfloor;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Provider.GetPlayer().transform.position.y > -37) {
			TWOfloor.SetActive(true);
		}
		if (Provider.GetPlayer().transform.position.y < -38) {
			TWOfloor.SetActive(false);
		}
	}
}
