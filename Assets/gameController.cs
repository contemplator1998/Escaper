using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {


    const int allKeys = 0;
    const int maxEnemies = 50;
    const int maxKeys = 30;

    public Text playerText;
    public Image playerPanel;
    public Image keyImage; 

    int keyNumber = 0;
    Vector3[] enemiesStartPositions = new Vector3[maxEnemies];
        
	// Use this for initialization
	void Start () {
        Cursor.visible = false;

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

        if (col.gameObject.name.StartsWith("Enemy"))
        {
            onKilled();
        }
        if (col.gameObject.name == "Gates")
        {
            onTryingFinish();
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
        keyImage.enabled = false;
        playerPanel.enabled = false;
        playerText.text = "";


        for (int i = 1; i <= maxEnemies; i++)
        {
            var enemy = GameObject.Find("Enemy" + i);
            if (enemy != null)
            {
                enemy.transform.position = enemiesStartPositions[i];
            }
        }
        var keys = GameObject.Find("Keys");
        keyController[] objs = keys.GetComponentsInChildren<keyController>();
        foreach(var obj in objs) {
            obj.GetComponentInChildren<SpriteRenderer>().enabled = true;
            obj.GetComponentInChildren<Light>().enabled = true;
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

    void onTryingFinish()
    {
        keyImage.enabled = false;
    }

    public void onKeyObtained()
    {
        StartCoroutine(SayKey());
    }

    public bool onTryKeyObtain()
    {
        bool hasKey = keyImage.enabled;
        if (hasKey)
        {
            StartCoroutine(SayCantKey());
        }
        return hasKey;
    }

    IEnumerator SayKey()
    {
        playerPanel.enabled = true;
        keyImage.enabled = true;
        playerText.text = "Hm... Key?";
        yield return new WaitForSeconds(2);
        playerText.text = "Nice";
        yield return new WaitForSeconds(2);
        playerText.text = "";
        playerPanel.enabled = false;

        keyNumber++;
    }

    IEnumerator SayCantKey()
    {
        playerPanel.enabled = true;
        keyImage.enabled = true;
        playerText.text = "Hm... Another key?";
        yield return new WaitForSeconds(2);
        playerText.text = "I've already got one. meh.";
        yield return new WaitForSeconds(2);
        playerText.text = "";
        playerPanel.enabled = false;

        keyNumber++;
    }
}
