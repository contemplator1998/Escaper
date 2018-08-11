using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        onStartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {

        Debug.Log("COLLIDED");

        if (col.gameObject.name == "Enemy")
        {
            onKilled();
        }
    }

    public void onStartGame()
    {
        var player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0, 0);
        var gameOver = GameObject.Find("GameOverImage");
        gameOver.GetComponent<Renderer>().enabled = false;
        GetComponent<movePlayer>().startMovingPlayer();
    }

    void onKilled()
    {
        var gameOver = GameObject.Find("GameOverImage");
        gameOver.GetComponent<Renderer>().enabled = true;
        GetComponent<movePlayer>().stopMovingPlayer();
    }
}
