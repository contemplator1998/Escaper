using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Provider
{
    private static GameObject gameplay;
    private static GameObject player;
    private static GameObject cursor;
    private static Slider lightIndicator;

    public static void Initialize()
    {
        gameplay = GameObject.Find("Gameplay");
        player = GameObject.Find("Player");
        cursor = GameObject.Find("Cursor");
        lightIndicator = GameObject.Find("LightIndicator").GetComponent<Slider>();
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
