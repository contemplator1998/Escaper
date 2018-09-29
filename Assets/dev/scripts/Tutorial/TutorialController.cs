using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : GameController
{
    void onFinished()
    {
		Debug.Log("SET MAIN CONTOLLER");
		Provider.setGeneralController(new GameController());
        SceneManager.LoadScene("MainScene");
    }

    public void onTryingFinish()
    {
		Debug.Log("tutor");
        keyImage.enabled = false;
        if (keyNumber++ >= allKeys)
        {
            this.onFinished();
        }
    }


	public void Start()
	{
		base.Start ();
		Debug.Log("SET TUTOR CONTOLLER");
		Provider.setGeneralController(this);
	}
}
