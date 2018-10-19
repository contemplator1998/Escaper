using System.Collections;
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
				Provider.GetController ().playerText.text = "E";
				isViewF = true;
			}
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
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
