using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatesController : LightedItem
{

	//public string NewSceneName = "MainScene";
	public Vector3 LocationOnNewScene;
	public int NeededNumberOfKeys;
	bool isViewF = false;
	// Use this for initialization

//	void OnCollisionEnter(Collision col)
//	{
//		
//		if (col.gameObject.name == Provider.GetPlayer().gameObject.name && Input.GetKeyDown(KeyCode.E))
//		{
//				if (Provider.GetController().keyNumber >= NeededNumberOfKeys)
//			{
//				Provider.GetController().onFinished();
//			}
//		}
//	}

	// Update is called once per frame
	void Update()
	{
		if (distance < 2)
		{
			if (!isViewF) {
				Provider.GetController ().playerText.text = "E";
				isViewF = true;
			}
			if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				Provider.GetController().playerText.text = "";
					Provider.GetController().onTryingFinish();
			}
		}
		else if (isViewF)
		{
			Provider.GetController().playerText.text = "";
			isViewF = false;
		}
	}
}
