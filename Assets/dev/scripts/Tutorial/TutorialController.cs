using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : GameController
{
    void onFinished()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onTryingFinish()
    {
        keyImage.enabled = false;
        if (keyNumber++ >= allKeys)
        {
            onFinished();
        }
    }
}
