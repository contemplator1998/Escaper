using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{

    float light = 0.8F;
    float lightSpeed = 0.8F;

    float lastLightFlutter = 0;
    float lastLightFlutterCoefficient = 0.8F;

    float maxLightCapacity = 1.0F;

    public void RefreshLight()
    {
        light = maxLightCapacity;
        StartCoroutine(Provider.GetController().SayLightRefreshed());
    }

    public void IncreaseLightCapacity()
    {
        maxLightCapacity += 0.5f;
        RefreshLight();
    }

    public float getLightSpeed()
    {
        return lightSpeed;
    }

    void Start()
    {

        Provider.GetPlayer().GetComponentInChildren<Light>().intensity = 2F + lightSpeed * 3F;
        Provider.GetPlayer().GetComponentInChildren<Light>().range = 15.0F + 25.0F * lightSpeed;
    }

    void Update()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetKey(KeyCode.Q) || d < 0)
        {
            lightSpeed -= 0.02F;
            lightSpeed = Mathf.Max(lightSpeed, 0.0F);
        }
        if (Input.GetKey(KeyCode.W) || d > 0)
        {
            lightSpeed += 0.02F;
            lightSpeed = Mathf.Min(lightSpeed, 1.0F);
        }
        if (light > 0)
        {
            light -= lightSpeed * 0.0003F;
        }
        if (light < 0.001F)
        {
            lightSpeed = 0;
        }
        var lightFlutter = lastLightFlutter * lastLightFlutterCoefficient +
            Random.Range(-0.1F, 0.1F) * (1.0F - lastLightFlutterCoefficient);
        var lightPower = lightSpeed + lightFlutter;
        lastLightFlutter = lightFlutter;
        Provider.GetPlayer().GetComponentInChildren<Light>().intensity = 0.5F + lightPower * 2.5F;
        Provider.GetPlayer().GetComponentInChildren<Light>().range = 15.0F + 25.0F * lightPower;
        Provider.GetLightIndicator().value = light;
    }
}
