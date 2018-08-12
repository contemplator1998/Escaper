using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlfriendTransform : MonoBehaviour {

    GameObject player;
    Light lamp;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        lamp = GetComponentInChildren<Light>();
    }

    bool isDark = true;
	
	// Update is called once per frame
    void Update()
    {
        var dist = Vector3.Magnitude(transform.position - player.transform.position);

        if (dist < 6)
        {
            lamp.intensity = 0;
        }
        else if (dist < 8)
        {
            lamp.intensity = (dist - 6) / 2.0F * 2.0F;
        }
        else
        {
            lamp.intensity = 2.0F;
        }


        if (dist < 6)
        {
            if (isDark)
            {
                Debug.Log(Resources.Load<Sprite>("images/enemy1"));
                GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("images/enemy1");
                isDark = false;
            }
        }
        else
        {
            if (!isDark)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("images/enemy1dark");
                isDark = true;
            }
        }
    }
}
