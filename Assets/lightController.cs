using System.Collections;
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            lightSpeed -= 0.01F;
            lightSpeed = Mathf.Max(lightSpeed, 0.0F);
            hpView.value = lightSpeed;
            Debug.Log(lightSpeed);
            lightDevice.intensity = 0.5F + lightSpeed * 1.5F;
            lightDevice.range = 15.0F + 25.0F * lightSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            lightSpeed += 0.01F;
            lightSpeed = Mathf.Min(lightSpeed, 1.0F);
            hpView.value = lightSpeed;
            Debug.Log(lightSpeed);
            lightDevice.intensity = 0.5F + lightSpeed * 1.5F;
            lightDevice.range = 15.0F + 25.0F * lightSpeed;
        }
        if (light > 0)
        {
            light -= lightSpeed * 0.001F;
        }
        lightView.value = light;
        hpView.value = Mathf.Max(hpView.value - 0.01F, 0.0F);
    }
}
