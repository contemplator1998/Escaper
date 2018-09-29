using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlfriendTransform : MonoBehaviour {

    GameObject player;
    Light lamp;

	public Sprite Dark;
	public Sprite noDark;
	// Use this for initialization
	void Start () {
        player = Provider.GetPlayer();
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
				GetComponentInChildren<SpriteRenderer>().sprite = noDark;
                isDark = false;
            }
        }
        else
        {
            if (!isDark)
            {
				GetComponentInChildren<SpriteRenderer>().sprite = Dark;
                isDark = true;
            }
        }
    }
}
