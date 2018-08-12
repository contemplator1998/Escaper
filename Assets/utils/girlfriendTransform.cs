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
        if (dist < 8)
        {
            if (isDark)
            {
                Debug.Log(Resources.Load<Sprite>("images/enemy1"));
                GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("images/enemy1");
                lamp.enabled = false;
                isDark = false;
            }
        }
        else
        {
            if (!isDark)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("images/enemy1dark");
                isDark = true;
                lamp.enabled = true;
            }
        }
    }
}
