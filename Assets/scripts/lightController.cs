﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightController : MonoBehaviour {

    float light = 0.8F;
    float lightSpeed = 0.8F;
    float hp = 1.0F;

    public Slider lightView;
    public Slider hpView;
    public Light lightDevice;

	public void RefreshLight() 
	{
		light = 1.0F;
	}

	public void IncreaseHp() {
		hp += 0.1F;
	}

	public float getLightSpeed()
	{
		return lightSpeed;
	}

	// Use this for initialization
	void Start () {

        lightDevice.intensity = 2F + lightSpeed * 3F;
        lightDevice.range = 15.0F + 25.0F * lightSpeed;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            lightSpeed -= 0.02F;
            lightSpeed = Mathf.Max(lightSpeed, 0.0F);
        }
        if (Input.GetKey(KeyCode.W))
        {
            lightSpeed += 0.02F;
            lightSpeed = Mathf.Min(lightSpeed, 1.0F);
        }
        if (light > 0)
        {	
            light -= lightSpeed * 0.0003F;
        }
		lightDevice.intensity = 0.5F + lightSpeed * 2.5F;
		lightDevice.range = 15.0F + 25.0F * lightSpeed;
        lightView.value = light;
        hpView.value = Mathf.Max(hpView.value - 0.0F, 0.0F);
    }
}
