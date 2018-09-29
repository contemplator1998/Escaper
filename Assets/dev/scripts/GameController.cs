using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour, Controller {


    public int allKeys = 3;
    const int maxEnemies = 50;
    const int maxKeys = 30;

    public Text playerText;
    public Text looseText;
    public Image playerPanel;
    public Image keyImage;
	public int keyNumber = 0;
    public GameObject allEnemies;

    public GameObject menu;
    private bool isShowingMenu;
	Vector3 DataPosition;
    EnemyControl[] enemies;
    GameObject eventSystem;


	// Use this for initialization
    public void Start()
	{Debug.Log("main");
        Cursor.visible = false;
        enemies = allEnemies.GetComponentsInChildren<EnemyControl>();
        onStartGame();
        playerText.text = "";
        eventSystem = GameObject.Find("EventSystem");
        eventSystem.SetActive(isShowingMenu);

    }
	
	// Update is called once per frame
	public void Update () {
        if (Input.GetKeyDown("escape"))
        {
            isShowingMenu = !isShowingMenu;
            menu.SetActive(isShowingMenu);
            eventSystem.SetActive(isShowingMenu);
        }
	}

    public void onStartGame()
    {
        var gameOver = GameObject.Find("GameOverImage");
        gameOver.GetComponent<Renderer>().enabled = false;
        gameOver.GetComponentInChildren<MeshRenderer>().enabled = false;
        Provider.GetPlayer().GetComponent<MovePlayer>().startMovingPlayer();
        keyImage.enabled = false;
        playerPanel.enabled = false;
        playerText.text = "";
        looseText.text = "";
        keyNumber = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].moveToStartPosition();
        }

        var keys = GameObject.Find("Keys");
        KeyController[] objs = keys.GetComponentsInChildren<KeyController>();
        foreach (var obj in objs)
        {
            obj.GetComponentInChildren<Light>().enabled = true;
        }
    }

    public void onKilled(GameObject gameObj)
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
		else if (name == "enemy6")
		{
			looseText.text = "ПРАПОРЩИК\nПоздравляю, тебе повестка";
        }
        Provider.GetPlayer().GetComponent<MovePlayer>().stopMovingPlayer();
        Provider.GetPlayer().GetComponent<MovePlayer>().moveToStartPosition();
    }

    public void onFinished()
    {
		Debug.Log("main");
        var gameOver = GameObject.Find("GameFinishedImage");
        gameOver.GetComponent<SpriteRenderer>().sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        gameOver.GetComponent<Renderer>().enabled = true;
        gameOver.GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponent<MovePlayer>().stopMovingPlayer();
        looseText.text = "Nice";
    }

    public void onTryingFinish()
    {
		Debug.Log("main");
        keyImage.enabled = false;
        if (keyNumber++ >= allKeys)
        {
            onFinished();
        }
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
    }

    public IEnumerator SayLightRefreshed()
    {
        playerPanel.enabled = true;
        playerText.text = "Thank goodness!";
        yield return new WaitForSeconds(1);
        playerText.text = "Now I have a light\nfor a while";
        yield return new WaitForSeconds(2);
        playerText.text = "";
        playerPanel.enabled = false;
    }


    public void onExitGame()
    {
        Application.Quit();
    }

    public void onResumeGame()
    {
        Debug.Log("On resume game");
        isShowingMenu = false;
        menu.SetActive(isShowingMenu);
    }
}
