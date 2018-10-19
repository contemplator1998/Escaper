﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : LightedItem
{
	bool isViewF = false;
    // Use this for initialization
    public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
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
				Provider.GetController().playerText.text = "";
				if (this.enabled &&
                    !Provider.GetController().onTryKeyObtain())
                {
                    Provider.GetController().onKeyObtained();
                    GetComponentInChildren<SpriteRenderer>().enabled = false;
					GetComponentInChildren<SphereCollider>().enabled = false;
                    GetComponentInChildren<Light>().enabled = false;
                }
            }
        }
		else if (isViewF)
		{
			Provider.GetController().playerText.text = "";
		}
    }
}
