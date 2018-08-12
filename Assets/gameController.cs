using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {


    const int allKeys = 0;
    const int maxEnemies = 50;

    public Text playerText;

    int keyNumber = 0;
    Vector3[] enemiesStartPositions = new Vector3[maxEnemies];
        
	// Use this for initialization
	void Start () {
        for (int i = 1; i <= maxEnemies; i++)
        {
            var enemy = GameObject.Find("Enemy" + i);
            if (enemy != null)
            {
                enemiesStartPositions[i] = enemy.transform.position;
            }
        }

        onStartGame();
        playerText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision col)
    {

        Debug.Log("COLLIDED");

        if (col.gameObject.name.StartsWith("Enemy"))
        {
            onKilled();
        }
        if (col.gameObject.name == "Gates")
        {
            if (keyNumber >= allKeys)
            {
                onFinished();
            }
        }
    }

    public void onStartGame()
    {
        var player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0, 0);
        var gameOver = GameObject.Find("GameOverImage");
        gameOver.GetComponent<Renderer>().enabled = false;
        GetComponent<movePlayer>().startMovingPlayer();


        for (int i = 1; i <= maxEnemies; i++)
        {
            var enemy = GameObject.Find("Enemy" + i);
            if (enemy != null)
            {
                enemy.transform.position = enemiesStartPositions[i];
            }
        }
    }

    void onKilled()
    {
        var gameOver = GameObject.Find("GameOverImage");
        gameOver.GetComponent<Renderer>().enabled = true;
        GetComponent<movePlayer>().stopMovingPlayer();
    }

    void onFinished()
    {
        var gameOver = GameObject.Find("GameFinishedImage");
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

        keyNumber++;
    }
}
