using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provider
{
    private static GameObject player;

    public static void Initialize()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    public static GameObject GetPlayer()
    {
        return player;
    }
}
