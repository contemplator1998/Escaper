using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : LightedItem
{

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
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
				if (this.enabled &&
                    !Provider.GetController().onTryKeyObtain())
                {
                    Provider.GetController().onKeyObtained();
                    GetComponentInChildren<SpriteRenderer>().enabled = false;
                    GetComponentInChildren<Light>().enabled = false;
                }
            }
        }
    }
}
