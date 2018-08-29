using UnityEngine;
using System.Collections;

public class LightedItem : MonoBehaviour
{
    protected float distance;
    Light lightDevice;

    float lightPower = 0;

    public void Start()
    {
        lightDevice = GetComponentInChildren<Light>();
    }

    public void Update()
    {
        distance = (transform.position - Provider.GetPlayer().transform.position).magnitude;
        if (distance > 10.0F)
        {
            lightPower = 0.1F;
        }
        else
        {
            lightPower = (10.0F - distance) / 8.0F;
        }
        lightDevice.intensity = 0.5F + lightPower * 2.5F;
        lightDevice.range = 15.0F + 25.0F * lightPower;
    }
}
