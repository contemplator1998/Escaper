using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Controller {

	void Start ();
	void Update ();

	void OnCollisionEnter (Collision col);

	void onStartGame ();

	void onKilled (GameObject gameObj);

	void onFinished ();
	void onTryingFinish ();

	void onKeyObtained ();

	bool onTryKeyObtain ();

	IEnumerator SayKey ();

	IEnumerator SayCantKey ();
}
