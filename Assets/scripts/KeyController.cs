using System.Collections;
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
		if (distance < 2 && GetComponentInChildren<SpriteRenderer>().enabled == true)
        {
			if (!isViewF) {
				Provider.GetController ().playerText.text = "E";
				isViewF = true;
			}
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
				Provider.GetController().playerText.text = "";
				if (this.enabled &&
                    !Provider.GetController().onTryKeyObtain())
                {
                    SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
                    SphereCollider sphere = GetComponentInChildren<SphereCollider>();
                    Light light = GetComponentInChildren<Light>();
                    Provider.GetController().onKeyObtained(sprite, sphere, light);
                    GetComponentInChildren<SpriteRenderer>().enabled = false;
					GetComponentInChildren<SphereCollider>().enabled = false;
                    GetComponentInChildren<Light>().enabled = false;
                }
            }
        }
		else if (isViewF)
		{
			Provider.GetController().playerText.text = "";
			isViewF = false;
		}
    }
}
