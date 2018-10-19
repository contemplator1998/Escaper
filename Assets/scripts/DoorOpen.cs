using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : LightedItem {
	public GameObject Door;
	bool isViewF = false;
	
	// Update is called once per frame
	void Update () {
		if ((transform.position - Provider.GetPlayer().transform.position).magnitude < 2)
		{
			if (!isViewF) {
				Provider.GetController ().playerText.text = "E";
				isViewF = true;
			}
			if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				Door.SetActive (false);
				Debug.Log ("false");
				gameObject.transform.Find ("dont_active").gameObject.SetActive (false);
				gameObject.transform.Find ("active").gameObject.SetActive (true);
				Provider.GetController().playerText.text = "";
			}
		}
		else if (isViewF)
		{
			Provider.GetController().playerText.text = "";
			isViewF = false;
			Debug.Log ("door");
		}
	}
}
