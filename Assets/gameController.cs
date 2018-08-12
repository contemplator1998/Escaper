using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameController : MonoBehaviour {


    const int allKeys = 0;
    const int maxEnemies = 50;
    const int maxKeys = 30;

    public Text playerText;
    public Text looseText;
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
            onKilled(col.gameObject);
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
        gameOver.GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<movePlayer>().startMovingPlayer();
        keyImage.enabled = false;
        playerPanel.enabled = false;
        playerText.text = "";
        looseText.text = "";


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

    void onKilled(GameObject gameObj)
    {
        var gameOver = GameObject.Find("GameOverImage");
        gameOver.GetComponent<SpriteRenderer>().sprite = gameObj.GetComponentInChildren<SpriteRenderer>().sprite;
        gameOver.GetComponent<Renderer>().enabled = true;
        gameOver.GetComponentInChildren<MeshRenderer>().enabled = true;
        string name = gameObj.GetComponentInChildren<SpriteRenderer>().sprite.name;
        if (name == "enemy1")
        {
            looseText.text = "ТВОЯ БЫВШАЯ\nВозвращение к ней тебя и убило";
        }
        else if (name == "enemy2")
        {
            looseText.text = "ПРИЗРАК СПОЙЛЕР\nИнформация о её смерти свела и вас в могилу";
        }
        else if (name == "enemy3")
        {
            looseText.text = "НЯШНЫЙ МОНСТР\nВы не умерли, вы просто нашли себе вайфу и следуете за новым сенпаем";
        }
        else if (name == "enemy4")
        {
            looseText.text = "ЗМЕЙ НА БЕРЕМЕННОСТЬ\nПоздравляю, теперь вы родитель и у вас нет сил на жизнь";
        }
        else if (name == "enemy5")
        {
            looseText.text = "КРАСНЫЙ ФОНАРЬ\nЭто просто красный фонарь";
        }
        GetComponent<movePlayer>().stopMovingPlayer();
    }

    void onFinished()
    {
        var gameOver = GameObject.Find("GameFinishedImage");
        gameOver.GetComponent<SpriteRenderer>().sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        gameOver.GetComponent<Renderer>().enabled = true;
        gameOver.GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponent<movePlayer>().stopMovingPlayer();
        looseText.text = "Nice";
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
