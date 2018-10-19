﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRefresherController : LightedItem
{
	bool isViewF = false;
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
        if (distance < 2)
        {
			if (!isViewF) {
				Provider.GetController ().playerText.text = "F";
				isViewF = true;
			}
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Provider.GetLightController().RefreshLight();
            }
        }
		else if (isViewF)
		{
			Provider.GetController().playerText.text = "";
			isViewF = false;
		}
    }
}
