using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialog : MonoBehaviour {

	private Text playerDialogText;
	private Image playerDialogPanel;

	public string Dialog;
	public int ViewTime;

	public bool isEnter = true;
	public bool isTriggered = false;

	void Start()
	{
		playerDialogPanel = GameObject.Find("SpeechPanel").GetComponent<Image>();
		playerDialogText = GameObject.Find("SpeechText").GetComponent<Text>();
	}

	void OnTriggerEnter (Collider col)
	{
		if (isEnter) {
			if (!isTriggered) {
				if (col.transform.CompareTag ("Player")) {
					StartCoroutine (Say ());
					isTriggered = true;
				}
			}
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (!isEnter) {
			if (!isTriggered) {
				if (col.transform.CompareTag ("Player")) {
					StartCoroutine (Say ());
					isTriggered = true;
				}
			}
		}
	}

	IEnumerator Say()
	{
		playerDialogPanel.enabled = true;
		playerDialogText.text = Dialog;
		yield return new WaitForSeconds(ViewTime);
		playerDialogText.text = "";
		playerDialogPanel.enabled = false;
	}
}
