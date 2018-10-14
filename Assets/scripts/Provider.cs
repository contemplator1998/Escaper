using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Provider
{
	private static GameObject gameplay;
	private static GameObject player;
	private static GameObject cursor;
	private static Slider lightIndicator;
	private static Controller controller;

	private static bool requstStartPlayerPosition = false;
	private static Vector3 startPlayerPosition;

	public static void Initialize()
	{
		gameplay = GameObject.Find("Gameplay");
		player = GameObject.Find("Player");
		cursor = GameObject.Find("Cursor");
		lightIndicator = GameObject.Find("LightIndicator").GetComponent<Slider>();
	}

	public static void RequstStartPlayerPosition(Vector3 position)
	{
		startPlayerPosition = position;
		requstStartPlayerPosition = true;
	}

	public static bool IsStartPlayerPositionRequested()
	{
		return requstStartPlayerPosition;
	}

	public static Vector3 GetStartPlayerPosition()
	{
		return startPlayerPosition;
	}

	public static void SetGeneralController(Controller value)
	{
		controller = value;
	}

	public static GameObject GetPlayer()
	{
		if (player == null)
		{
			Initialize();
		}
		return player;
	}

	public static GameObject GetGameplay()
	{
		if (gameplay == null)
		{
			Initialize();
		}
		return gameplay;
	}

	public static TutorialController getGeneralController()
	{
		return (TutorialController) controller;
	}

	public static GameController GetController()
	{
		if (gameplay == null)
		{
			Initialize();
		}
		return gameplay.GetComponent<GameController>();
	}

	public static LightController GetLightController()
	{
		if (gameplay == null)
		{
			Initialize();
		}
		return gameplay.GetComponent<LightController>();
	}

	public static GameObject GetCursor()
	{
		if (cursor == null)
		{
			Initialize();
		}
		return cursor;
	}

	public static Slider GetLightIndicator()
	{
		if (lightIndicator == null)
		{
			Initialize();
		}
		return lightIndicator;
	}
}
