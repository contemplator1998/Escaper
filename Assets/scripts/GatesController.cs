using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatesController : MonoBehaviour
{

	//public string NewSceneName = "MainScene";
	public Vector3 LocationOnNewScene;
	public int NeededNumberOfKeys;


	// Use this for initialization
	void Start()
	{
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == Provider.GetPlayer().gameObject.name)
		{
				if (Provider.GetController().keyNumber >= NeededNumberOfKeys)
			{
				Provider.GetController().onFinished();
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
	}
}
