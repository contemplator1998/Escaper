using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRefresherController : LightedItem
{

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
        if (distance < 2)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Provider.GetLightController().RefreshLight();
            }
        }
    }
}
