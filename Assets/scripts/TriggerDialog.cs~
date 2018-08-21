using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialog : MonoBehaviour {

	public Text playerText;
	public Image playerPanel;
	public string Dialog;
	public int ViewTime;

	public bool isTriggered = false;

	void OnTriggerEnter (Collider col)
	{
		if (!isTriggered) {
			StartCoroutine (Say ());
			isTriggered = true;
		}
	}

	IEnumerator Say()
	{
		playerPanel.enabled = true;
		playerText.text = Dialog;
		yield return new WaitForSeconds(ViewTime);
		playerText.text = "";
		playerPanel.enabled = false;
	}
}
