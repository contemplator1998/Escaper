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
		Provider.GetPlayer().GetComponent<AlternativeMove>().startMovingPlayer();
        keyImage.enabled = false;
        playerPanel.enabled = false;
        playerText.text = "";
        looseText.text = "";
        keyNumber = 0;
		Provider.GetLightController().RefreshLight();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].moveToStartPosition();
        }

        var keys = GameObject.Find("Keys");
        KeyController[] objs = keys.GetComponentsInChildren<KeyController>();
        foreach (var obj in objs)
        {
			obj.GetComponentInChildren<SpriteRenderer>().enabled = true;
			obj.GetComponentInChildren<SphereCollider>().enabled = true;
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
		else if (name == "enemy6")
		{
			looseText.text = "ДИВАННЫЙ КРИТИК\nАффффтор лох";
		}
		Provider.GetPlayer().GetComponent<AlternativeMove>().stopMovingPlayer();
		Provider.GetPlayer().GetComponent<AlternativeMove>().moveToStartPosition();
    }

    public void onFinished()
    {
		Debug.Log("main");
		keyImage.enabled = false;
        var gameOver = GameObject.Find("GameFinishedImage");
        gameOver.GetComponent<Renderer>().enabled = true;
        gameOver.GetComponentInChildren<MeshRenderer>().enabled = true;
        looseText.text = "Норм";
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
        keyImage.enabled = true;
		playerText.text = "Хм ... ключ?";
        yield return new WaitForSeconds(2);
        playerText.text = "Норм";
        yield return new WaitForSeconds(2);
        playerText.text = "";

        keyNumber++;
    }

    IEnumerator SayCantKey()
    {
        keyImage.enabled = true;
        playerText.text = "Хм ... другой ключ?";
        yield return new WaitForSeconds(2);
        playerText.text = "Но я не унес больше";
        yield return new WaitForSeconds(2);
        playerText.text = "";
    }

    public IEnumerator SayLightRefreshed()
    {
        playerText.text = "Слава египетским богам!";
        yield return new WaitForSeconds(2);
        playerText.text = "";
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