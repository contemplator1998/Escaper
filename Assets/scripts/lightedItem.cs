using UnityEngine;
using System.Collections;

public class itemLightning : MonoBehaviour
{
    protected GameObject player;
    protected float distance;
    Light lightDevice;

    float lightPower = 0;

	// Use this for initialization
	public void Start()
	{
        player = GameObject.Find("Player");
        lightDevice = GetComponentInChildren<Light>();
	}

	// Update is called once per frame
	public void Update()
	{
        distance = (transform.position - player.transform.position).magnitude;
        if (distance > 10.0F)
        {
            lightPower = 0.1F;
        }
        else
        {
            lightPower = (10.0F - distance) / 3.0F;
        }
        lightDevice.intensity = 0.5F + lightPower * 2.5F;
        lightDevice.range = 15.0F + 25.0F * lightPower;
	}
}
