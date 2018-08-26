using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provider
{
    private static GameObject player;

    public static void Initialize()
    {
        player = GameObject.Find("Player");
    }

    public static GameObject GetPlayer()
    {
        if (player == null)
        {
            Initialize();
        }
        return player;
    }
}
