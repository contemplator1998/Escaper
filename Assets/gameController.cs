using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

    public Text playerText;
        
	// Use this for initialization
	void Start () {
        onStartGame();
        playerText.text = "";
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

    public void onKeyObtained()
    {
        StartCoroutine(SayKey());
    }

    IEnumerator SayKey()
    {
        playerText.text = "Hm... Key?";
        yield return new WaitForSeconds(2);
        playerText.text = "Nice";
        yield return new WaitForSeconds(2);
        playerText.text = "";
    }
}
