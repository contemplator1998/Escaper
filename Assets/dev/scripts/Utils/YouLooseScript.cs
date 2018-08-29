using UnityEngine;
using System.Collections;

public class YouLooseScript : MonoBehaviour
{

    // Use this for initialization

    GameObject gameOver;

    void Start()
    {
        gameOver = GameObject.Find("GameOverImage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameOver.GetComponent<Renderer>().enabled)
        {
            var player = GameObject.Find("Player");
            Provider.GetController().onStartGame();
        }
    }
}
